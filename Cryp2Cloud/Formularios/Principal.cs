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

namespace Cryp2Cloud.Formularios
{
    public partial class Principal : Form
    {
        //Nombre de usuario para mantener sesión
        public string _usuario = null;

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

        //Botón que encripta los archivos seleccionados
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
                MessageBox.Show("Debe introducir un método de cifrado");
                return;
            }

            foreach(String direccion in rutas)
            {
                String fileName = System.IO.Path.GetFileName(direccion) + cifrado;
                foreach(String destino in rutasCifrado)
                {
                    String ficheroDestino = System.IO.Path.Combine(destino, fileName);
                    System.IO.File.Copy(direccion, ficheroDestino, true);
                }
            }
            listaArchivos.Clear();
        }

        //Desencripta los archivos seleccionados del panel de control derecho en la carpeta de descarga seleccionada
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            GongSolutions.Shell.ShellItem[] elementos = Vista_carpeta.SelectedItems;
            foreach(GongSolutions.Shell.ShellItem elemento in elementos)
            {
                String rutaElemento = elemento.FileSystemPath;
                //Comprueba si la extensión del archivo es AES
                switch(System.IO.Path.GetExtension(rutaElemento))
                {
                    case ".aes": //Caso de que sea aes

                        break;
                    case ".rc4": //Caso de que sea RC4

                        break;
                    default:
                        return;
                }
      
                String nombre = System.IO.Path.GetFileNameWithoutExtension(rutaElemento);
                String ruta = System.IO.Path.GetDirectoryName(rutaElemento);
                String ficheroDestino = System.IO.Path.Combine(_dir_descarga, nombre);

                try
                {
                    //Copia el elemento en la ruta de descargas
                    System.IO.File.Copy(rutaElemento, ficheroDestino, true);
                    Process.Start("explorer.exe", _dir_descarga);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("No tiene permisos para guardar en este directorio");
                }

            }
            
        }

        //Cargamos en una lista los directorios de los servicios que debemos de copiar
        private void CargarMétodos()
        {
            //Limpiamos la lista de cifrado por si hubieran cambiado sus valores
            rutasCifrado.Clear();
            if(_checkDrive)
            {
                rutasCifrado.Add(_dirDrive);
            }
            if(_checkDrop)
            {
                rutasCifrado.Add(_dirDrop);
            }
            if(_checkMega)
            {
                rutasCifrado.Add(_dirMega);
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
            form._usuario = this._usuario;
            form._principal = this;
            form.ShowDialog();
        }

        private void btn_crypt_MouseEnter(object sender, EventArgs e)
        {
            btn_crypt.BackgroundImage = Cryp2Cloud.Properties.Resources.crypt_presionado;
        }

        private void btn_crypt_MouseLeave(object sender, EventArgs e)
        {
            btn_crypt.BackgroundImage = Cryp2Cloud.Properties.Resources.crypt_normal;
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
            btn_decrypt.BackgroundImage = Cryp2Cloud.Properties.Resources.decrypt_normal;
        }

        private void btn_decrypt_MouseLeave(object sender, EventArgs e)
        {
            btn_decrypt.BackgroundImage = Cryp2Cloud.Properties.Resources.decrypt_precionado;
        }

        private void Principal_Activated(object sender, EventArgs e)
        {
            this.Refresh();
            CargarMétodos();
        }
    }
}
