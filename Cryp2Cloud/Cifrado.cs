using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
    }
}
