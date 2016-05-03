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


        public Principal()
        {
            InitializeComponent();
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            label_usuario.Text = _usuario.ToUpper();
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
        }

        

        
    }
}