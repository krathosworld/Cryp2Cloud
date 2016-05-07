using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Security;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Cryp2Cloud.Formularios
{
    public partial class Principal : Form
    {
        //Nombre de usuario para mantener sesión
        public string _usuario = null;
        public string _password = null;

        //Rutas de los campos a copiar
        public string _dirDrop = null;
        public string _dirMega = null;
        public string _dirDrive = null;
        public string _dir_descarga = null;

        //Validación de las rutas a copiar
        public bool _checkDrop = false;
        public bool _checkMega = false;
        public bool _checkDrive = false;

        //Listado con las rutas a los archivos a convertir
        List<String> rutas = new List<string>();

        //Listado con las rutas disponibles para copiar archivos
        List<String> rutasCifrado = new List<string>();


        public Principal()
        {
            InitializeComponent();
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            label_usuario.Text = _usuario.ToUpper();
            CargarMétodos();
        }

        //Botón que cifra los archivos seleccionados
        private void btn_crypt_Click(object sender, EventArgs e)
        {
            //Comprueba el método de cifrado que se ha de emplear
            //En caso de no haberse seleccionado ninguno mostrará un mensaje de aviso
            String cifrado = "";
            if((string)lista_cifrado.SelectedItem=="AES")
            {
                cifrado = ".aes";
            }
            else if ((string)lista_cifrado.SelectedItem == "RC4")
            {
                cifrado = ".rc4";
            }
            else
            {
                MessageBox.Show("Debe introducir un método de cifrado","Atención",MessageBoxButtons.OK);
                return;
            }

            String error = "";
            foreach (String direccion in rutas)
            {
                String fileName = System.IO.Path.GetFileName(direccion) + cifrado;
                //Comprobar si el archivo ya existe en la BD
                if (buscarArchivoBD(fileName)!="")
                {
                    error += "El archivo " + fileName + " ya ha sido cifrado\n";
                }
                else
                {
                    String ContAleatoria = Cifrado.CrearClaveAleatoria(16);
                    Byte[] PassMaestra = Cifrado.GenerarClaveByte(_password, 32);
                    String PassArchivo = Cifrado.CifrarPassArchivoAES(ContAleatoria, PassMaestra);
                    if (cifrado == ".aes")
                    {
                        //Generamos las claves necesarias para el cifrado en AES
                        //Se llama a la función que cifra por AES
                        if (Cifrado.CifrarAES(direccion, ContAleatoria))
                        {
                            InsertarArchivoBD(fileName,PassArchivo);
                            CopiaArchivo(direccion+cifrado,fileName);
                        }
                    }
                    else
                    {
                        //Se llama a la función que cifra por RC4
                        if(Cifrado.RC4(direccion,direccion+cifrado, ContAleatoria))
                        {
                            InsertarArchivoBD(fileName, PassArchivo);
                            CopiaArchivo(direccion + cifrado, fileName);
                        }
                    }

                }
            }
            if(error!="")
            {
                MessageBox.Show(error,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Todos los archivos se han cifrado con éxito","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            listaArchivos.Clear();
            rutas.Clear();
        }

        private void InsertarArchivoBD(String nombre, String passArchivo)
        {
            //Inicializamos el DataSet que conecta con la tabla usuarios
            BBDDDataSetTableAdapters.ArchivoCifradoTableAdapter archivoTableAdapter;
            archivoTableAdapter = new BBDDDataSetTableAdapters.ArchivoCifradoTableAdapter();
            //Insertamos el nuevo usuario en la base de datos
            archivoTableAdapter.Insert(nombre, passArchivo, _usuario);
        }

        private void CopiaArchivo(String rutaArchivo,String fileName)
        {
            foreach (String destino in rutasCifrado) //Bucle que itera en cada una de las rutas a copiar el archivo
            {
                String ficheroDestino = System.IO.Path.Combine(destino, fileName); //Crea la ruta completa del archivo a crear
                System.IO.File.Copy(rutaArchivo, ficheroDestino, true); //Copia el archivo de respaldo en cada una de las rutas especificadas
            }
            System.IO.File.Delete(rutaArchivo); //Elimina el archivo de respaldo
        }

        //Desencripta los archivos seleccionados del panel de control derecho en la carpeta de descarga seleccionada
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            //GongSolutions.Shell.ShellItem[] elementos = Vista_carpeta.SelectedItems;
            //foreach(GongSolutions.Shell.ShellItem elemento in elementos)
            //{
                //String rutaElemento = elemento.FileSystemPath;
            foreach (String rutaElemento in rutas)
            {
                String nombreElemento = System.IO.Path.GetFileName(rutaElemento);
                String PassBD = buscarArchivoBD(nombreElemento);
                String nombre = System.IO.Path.GetFileNameWithoutExtension(rutaElemento);
                String ruta = System.IO.Path.GetDirectoryName(rutaElemento);
                String ficheroDestino = System.IO.Path.Combine(_dir_descarga, nombre);
                String error = "";
                if (PassBD == "")
                {
                    error += "El archivo " + nombreElemento + " no está cifrado\n";
                }
                else
                {
                    Byte[] PassMaestra = Cifrado.GenerarClaveByte(_password, 32);
                    String PassArchivo = Cifrado.DescifrarPassArchivoAES(PassBD, PassMaestra);
                    Byte[] ContAleatoria = Cifrado.GenerarClaveByte(PassArchivo, 16);
                    //Comprueba si la extensión del archivo es AES o RC4
                    switch (System.IO.Path.GetExtension(rutaElemento))
                    {
                        case ".aes": //Caso de que sea aes
                            //Desciframos el archivo e AES
                            Cifrado.DescifrarAES(rutaElemento, ficheroDestino, ContAleatoria);
                            break;

                        case ".rc4": //Caso de que sea RC4
                            //Desciframos el archivo en RC4
                            Cifrado.RC4(rutaElemento,ficheroDestino, PassArchivo);

                            break;
                        default:
                            return;
                    }
                }

                if(error!="")
                {
                    MessageBox.Show(error,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Todos los archivos se han descifrado con éxito","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
            listaArchivos.Clear();
            rutas.Clear();
            Process.Start("explorer.exe", _dir_descarga);
        }

        //Cargamos en una lista los directorios de los servicios que debemos de copiar
        public void CargarMétodos()
        {
            //Limpiamos la lista de cifrado por si hubieran cambiado sus valores
            rutasCifrado.Clear();
            if(_checkDrive)
            {
                rutasCifrado.Add(_dirDrive);
                bt_drive.BackgroundImage = Cryp2Cloud.Properties.Resources.Google_Drive_icon;
                bt_drive.Cursor = Cursors.Hand;
            }
            else
            {
                bt_drive.Cursor = Cursors.Arrow;
                bt_drive.BackgroundImage = Cryp2Cloud.Properties.Resources.Google_Drive_icon_bn;
            }
            if (_checkDrop)
            {
                rutasCifrado.Add(_dirDrop);
                bt_dropbox.BackgroundImage = Cryp2Cloud.Properties.Resources.dropbox_xxl;
                bt_dropbox.Cursor = Cursors.Hand;
            }
            else
            {
                bt_dropbox.BackgroundImage = Cryp2Cloud.Properties.Resources.dropbox_xxl_bn;
                bt_dropbox.Cursor = Cursors.Arrow;
            }
            if (_checkMega)
            {
                rutasCifrado.Add(_dirMega);
                bt_mega.BackgroundImage = Cryp2Cloud.Properties.Resources.unnamed;
                bt_mega.Cursor = Cursors.Hand;
            }
            else
            {
                bt_mega.BackgroundImage = Cryp2Cloud.Properties.Resources.mega_bn;
                bt_mega.Cursor = Cursors.Arrow;
            }
        }

        //Abre una ventana que permite seleccionar archivos para cargarlos en la ventana de principal
        private void btn_añadir_archivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog Explorador = new OpenFileDialog();
            Explorador.InitialDirectory = "c:\'";

            string Direccion = null;

            if (Explorador.ShowDialog() == DialogResult.OK)
            {
                Direccion = @Explorador.FileName;
                listaArchivos.Items.Add(Explorador.SafeFileName, 0); //Agrega el archivo a la lista de archivos en pantalla
                rutas.Add(Direccion); //Almacenamos la dirección del archivo en una lista
            }
        }

        private String buscarArchivoBD(String nombreArchivo)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Formularios\MiBaseDeDatos.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From ArchivoCifrado where Nombre =  '" + nombreArchivo + "' AND Usuario = '"+_usuario+"'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            if (rd.Read())
                            {
                                //Cargamos todos los datos de la BD
                                String PassArchivo = rd["PassCifrado"].ToString();
                                conn.Close();
                                return PassArchivo;
                            }
                        }
                    }
                    conn.Close();
                }
            }
            return "";
        }

        //MANEJADORES DE EVENTOS

        private void listaArchivos_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Copy;
        }

        //Carga la ruta del archivo arrastrado y la copia a una lista con el resto de las rutas
        //Añade el archivo a la ventana de archivos de principal
        //En el caso de ser una carpeta no realiza ninguna acción
        //Permite la carga de varios archivos simultaneos
        private void listaArchivos_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                if (!Directory.Exists(file)) //Comprueba que no se trate de una carpeta
                {
                    listaArchivos.Items.Add(Path.GetFileName(file), 0);
                    //Guardar en un array las direcciones de cada archivo
                    rutas.Add(file); //Agrega la ruta del archivo a la lista de rutas de los archivos
                }
            }
        }

        //Abre la ventana de configuración
        private void btn_ajustes_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion form = new Formularios.Configuracion();
            form.StartPosition = FormStartPosition.CenterScreen;
            form._usuario = this._usuario;
            form._principal = this;
            form.ShowDialog();
        }

        private void btn_crypt_MouseEnter(object sender, EventArgs e)
        {
            btn_crypt.BackgroundImage = Cryp2Cloud.Properties.Resources.Cifrar1;
        }

        private void btn_crypt_MouseLeave(object sender, EventArgs e)
        {
            btn_crypt.BackgroundImage = Cryp2Cloud.Properties.Resources.Cifrar2;
        }

        private void btn_añadir_archivo_MouseEnter(object sender, EventArgs e)
        {
            btn_añadir_archivo.BackgroundImage = Cryp2Cloud.Properties.Resources.añadir_archivos2;
        }

        private void btn_añadir_archivo_MouseLeave(object sender, EventArgs e)
        {
            btn_añadir_archivo.BackgroundImage = Cryp2Cloud.Properties.Resources.añadir_archivos1;
        }

        private void btn_decrypt_MouseEnter(object sender, EventArgs e)
        {
            btn_decrypt.BackgroundImage = Cryp2Cloud.Properties.Resources.Descifrar1;
        }

        private void btn_decrypt_MouseLeave(object sender, EventArgs e)
        {
            btn_decrypt.BackgroundImage = Cryp2Cloud.Properties.Resources.Descifrar2;
        }

        private void botonPasar_Click(object sender, EventArgs e)
        {
            GongSolutions.Shell.ShellItem[] elementos = Vista_carpeta.SelectedItems;
            foreach (GongSolutions.Shell.ShellItem elemento in elementos)
            {   
                if (!elemento.IsFolder) //Comprueba que no se trate de una carpeta
                {
                    String rutaElemento = elemento.FileSystemPath;
                    listaArchivos.Items.Add(Path.GetFileName(rutaElemento), 0);
                    //Guardar en un array las direcciones de cada archivo
                    rutas.Add(rutaElemento); //Agrega la ruta del archivo a la lista de rutas de los archivos
                }
            }
        }

        private void botonPasar_MouseEnter(object sender, EventArgs e)
        {
            botonPasar.BackgroundImage = Cryp2Cloud.Properties.Resources.crypt_presionado;
        }

        private void botonPasar_MouseLeave(object sender, EventArgs e)
        {
            botonPasar.BackgroundImage = Cryp2Cloud.Properties.Resources.crypt_normal;
        }

        private void bt_dropbox_Click(object sender, EventArgs e)
        {
            if(_checkDrop)
            {
                Process.Start("explorer.exe", _dirDrop);
            }
        }

        private void bt_drive_Click(object sender, EventArgs e)
        {
            if (_checkDrive)
            {
                Process.Start("explorer.exe", _dirDrive);
            }
        }

        private void bt_mega_Click(object sender, EventArgs e)
        {
            if (_checkMega)
            {
                Process.Start("explorer.exe", _dirMega);
            }
        }
    }
}
