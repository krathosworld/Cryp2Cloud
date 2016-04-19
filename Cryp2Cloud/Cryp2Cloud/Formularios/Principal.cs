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
    public partial class Principal: Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        //MANEJADORES DE EVENTOS
        private void btn_ajustes_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion form = new Formularios.Configuracion();
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

        private void btn_añadir_archivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog Explorador = new OpenFileDialog();
            Explorador.InitialDirectory = "c:\'";

            String Direccion = null;

            if (Explorador.ShowDialog() == DialogResult.OK)
            {
                Direccion = @Explorador.FileName;
                listaArchivos.Items.Add(Explorador.SafeFileName, 0);
                //Guardar en un array las direcciones de los archivos
            }
        }

        private void listaArchivos_DragEnter(object sender, DragEventArgs e)
        {
                
                e.Effect = DragDropEffects.Copy;
        }

        private void listaArchivos_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                if (!Directory.Exists(file))
                {
                    listaArchivos.Items.Add(Path.GetFileName(file), 0);
                    //Guardar en un array las direcciones de cada archivo
                }
            }
        }
    }
}
