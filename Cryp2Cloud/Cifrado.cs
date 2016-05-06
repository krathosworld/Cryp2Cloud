using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryp2Cloud
{
    class Cifrado
    {
        //Genera un hash salteado como string a partir de la 'password' y 'salt' pasada
        public static string GenerarSaltedHash(string password, string salt)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            //Se obtienen los bytes a partir de las cadenas
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);
            byte[] byteSalt = Encoding.UTF8.GetBytes(salt);

            //Combina los dos arrays de bytes
            byte[] byteCombinado = new byte[bytePassword.Length + byteSalt.Length];
            bytePassword.CopyTo(byteCombinado, 0);
            byteSalt.CopyTo(byteCombinado, bytePassword.Length);

            byte[] hash = sha256.ComputeHash(byteCombinado);//Se calcula el hash

            StringBuilder cadHex = new StringBuilder();

            //Recorre bytes pasandolos a una cadena hexadecimal
            for (int i = 0; i < hash.Length; i++)
            {
                cadHex.Append(hash[i].ToString("x2"));//Lo añade como 2 caracteres hex
            }

            return cadHex.ToString();
        }

        //Se genera una cadena aleatoria de determinado tamaño
        public static string GenerarCadenaAleatoria(int tam)
        {   // 26x2 letras - 10 num - 12 especiales
            char[] charPosibles = {   'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                                      'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                                      '0','1','2','3','4','5','6','7','8','9',
                                      '_','-','@','#','=','&','*','+','~','¬','<','>'};

            //Generador de números aleatorios
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rand = new byte[4];
            uint valorRand;

            StringBuilder pass = new StringBuilder();

            //Genera una cadena de un tamaño determinado
            for (int i = 0; i < tam; i++)
            {
                rng.GetBytes(rand);//Obtiene bytes aleatorios

                //Obtiene un entero sin signo dentro del rango
                valorRand = BitConverter.ToUInt32(rand, 0) % (uint)charPosibles.Length;

                pass.Append(charPosibles[valorRand]);//Va añadiendo chars aleatorios a la cadena
            }

            return pass.ToString();
        }

        //Genera la llave como byte[] a partir del hash, hasta un tamaño determinado
        public static byte[] GenerarClaveByte(string password, int tamKey)
        {
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();

            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));//Obtine el hash de la 'password'
            byte[] returnedHash = new byte[tamKey];

            //Copia los bytes del hash, hasta el tamaño especificado
            for (int i = 0; i < tamKey; i++)
            {
                returnedHash[i] = hash[i];
            }

            return returnedHash;
        }


        //Cifra un texto en AES, la contraseña se pasa ya crifrada mediante SHA de 32 bytes
        public static string GenerarPassAES(string text, Byte[] password)
        {
            //Crea el AES Crypto Service Provider
            var aes = new AesCryptoServiceProvider()
            {
                BlockSize = 128,
                KeySize = 256,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7, //Se hace por defecto
                Key = password
            };
            //Genera un vector de inicialización (IV) aleatorio
            aes.GenerateIV();

            //Obtiene IV
            byte[] bytesIV = aes.IV;

            //Convierte el texto de entrada a byte[]
            byte[] bytesText = Encoding.Unicode.GetBytes(text);

            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(bytesText, 0, bytesText.Length);

                //Añade el IV al principio, con un carácter de separación
                string ret = Convert.ToBase64String(aes.IV) + '$' + Convert.ToBase64String(dest);

                return ret;
            }
        }

        //Descifra un texto en AES
        public static string DescifrarPassAES(string passArchivo, byte[] password)
        {
            //Crea el AES Crypto Service Provider
            var aes = new AesCryptoServiceProvider()
            {
                BlockSize = 128,
                KeySize = 256,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7, //Lo asigna por defecto
                Key = password
            };

            //Separa el IV del texto cifrado
            string[] divided = passArchivo.Split('$');

            aes.IV = System.Convert.FromBase64String(divided[0]);
            byte[] src = System.Convert.FromBase64String(divided[1]);

            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }

        //Cifra un archivo 'origen' mediante AES y lo devuelve
        public static Boolean CifrarAES(string origen, string password)
        {
            //Tamaño de la llave
            int tamKey = 16;

            //Dirección de copia temporal
            String destino = origen + ".aes";

            //Genera la llave en bytes
            byte[] Clavebytes = GenerarClaveByte(password, tamKey);

            //Crea el AES Crypto Service Provider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider()
            {
                BlockSize = 128,
                KeySize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = Clavebytes,
            };

            //Genera un vector de inicialización (IV) aleatorio
            aes.GenerateIV();

            //Obtiene IV
            var bytesIV = aes.IV;


            try
            {
                //Crea un Stream de entrada, para el fichero que se quiere cifrar
                using (FileStream entrada = new FileStream(origen, FileMode.Open, FileAccess.Read))
                {
                    //Crea un Stream de salida, donde se almacenará el fichero ya cifrado
                    using (FileStream salida = new FileStream(destino, FileMode.Create, FileAccess.Write))
                    {
                        //Escribe el IV en el fichero de salida
                        salida.Write(bytesIV, 0, aes.BlockSize / 8);

                        //Crea el cifrador AES
                        using (ICryptoTransform encrypt = aes.CreateEncryptor())
                        {
                            //Crea el Crypto Stream para el destino
                            using (CryptoStream cs = new CryptoStream(salida, encrypt, CryptoStreamMode.Write))
                            {
                                while (true)
                                {
                                    Byte[] buffer = new byte[1024];
                                    //Se lee y se copia al buffer hasta que el tamaño del buffer sea ocupado por completo
                                    int len = entrada.Read(buffer, 0, buffer.Length);

                                    //Mientras no se llegue al final
                                    if (len > 0)
                                    {
                                        //Escribe lo leído al Crypto Stream
                                        cs.Write(buffer, 0, len);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("CifrarAES: Fichero origen a cifrar no encontrado.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("CifrarAES: Directorio no encontrado.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //Descifra un archivo 'origen' mediante AES y lo almacena en 'destino'
        public static void DescifrarAES(string origen, string destino, byte[] password)
        {

            //Crea el AES Crypto Service Provider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider()
            {
                BlockSize = 128,
                KeySize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = password,
            };

            //Crea el buffer del IV
            byte[] bytesIV = new byte[aes.BlockSize / 8];

            try
            {
                //Crea un Stream de entrada, para el fichero que se quiere descifrar
                using (var entrada = new FileStream(origen, FileMode.Open, FileAccess.Read))
                {
                    //Crea un Stream de salida, donde se almacenará el fichero ya descifrado
                    using (var salida = new FileStream(destino, FileMode.Create, FileAccess.Write))
                    {
                        //Lee el IV
                        entrada.Read(bytesIV, 0, aes.BlockSize / 8);

                        //Fija el IV
                        aes.IV = bytesIV;

                        //Crea el descifrador AES
                        using (var decrypt = aes.CreateDecryptor())
                        {
                            //Crea el Crypto Stream para el destino
                            using (var cs = new CryptoStream(salida, decrypt, CryptoStreamMode.Write))
                            {
                                while (true)
                                {
                                    var buffer = new byte[1024];
                                    //Se lee y se copia al buffer
                                    var len = entrada.Read(buffer, 0, buffer.Length);

                                    //Mientras no se llegue al final
                                    if (len > 0)
                                    {
                                        //Escribe lo leído al Crypto Stream
                                        cs.Write(buffer, 0, len);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("DescifrarAES: Fichero origen a descifrar no encontrado.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("DescifrarAES: Directorio no encontrado.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CryptographicException e)
            {
                //Borra el archivo malformado
                if (File.Exists(destino))
                    File.Delete(destino);

                //MessageBox.Show("DescifrarAES: Error al descifrar el archivo.\n Asegurese de que la contraseña es la correcta.", "ERROR",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(e.ToString());
            }
        }
    }
}
