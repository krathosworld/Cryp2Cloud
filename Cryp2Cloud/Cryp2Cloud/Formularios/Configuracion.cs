using System;
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
    public partial class Configuracion: Form
    {
        public Configuracion()
        {
            BigCheckBox check_dropbox = new BigCheckBox(405, 232,"check_dropbox");
            BigCheckBox check_drive = new BigCheckBox(405, 314,"check_drive");
            BigCheckBox check_mega = new BigCheckBox(405, 400,"check_mega");

            this.Controls.Add(check_dropbox);
            this.Controls.Add(check_drive);
            this.Controls.Add(check_mega);

            InitializeComponent();
        }

        class BigCheckBox : CheckBox
        {
            public BigCheckBox(int x, int y, string nombre)
            {
                this.Text = "\0";
                this.TextAlign = ContentAlignment.MiddleRight;
                this.Location = new Point (x,y);
                this.Name = nombre;
            }

            public override bool AutoSize
            {
                set { base.AutoSize = false; }
                get { return base.AutoSize; }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                this.Height = 25;
                this.Width = 25;
                int squareSide = 25;

                Rectangle rect = new Rectangle(new Point(0, 1), new Size(squareSide, squareSide));

                ControlPaint.DrawCheckBox(e.Graphics, rect, this.Checked ? ButtonState.Checked : ButtonState.Normal);
            }
        }

        private void btn_acceder_MouseEnter(object sender, EventArgs e)
        {
            btn_acceder.BackgroundImage = Cryp2Cloud.Properties.Resources.Guardar_cambios2;
        }

        private void btn_acceder_MouseLeave(object sender, EventArgs e)
        {
            btn_acceder.BackgroundImage = Cryp2Cloud.Properties.Resources.Guardar_cambios1;
        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btn_explorar_dropbox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Explorador = new FolderBrowserDialog();
            Explorador.SelectedPath = "c:\'";

            String Direccion = null;

            if(Explorador.ShowDialog() == DialogResult.OK)
            {
                Direccion = @Explorador.SelectedPath;
                textBox_dropbox.Text = Direccion;
            }
        }

        private void btn_explorar_drive_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Explorador = new FolderBrowserDialog();
            Explorador.SelectedPath = "c:\'";

            String Direccion = null;

            if (Explorador.ShowDialog() == DialogResult.OK)
            {
                Direccion = @Explorador.SelectedPath;
                textBox_drive.Text = Direccion;
            }

        }

        private void btn_explorar_mega_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Explorador = new FolderBrowserDialog();
            Explorador.SelectedPath = "c:\'";

            String Direccion = null;

            if (Explorador.ShowDialog() == DialogResult.OK)
            {
                Direccion = @Explorador.SelectedPath;
                textBox_mega.Text = Direccion;
            }
        }

        private void btn_explorar_descarga_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Explorador = new FolderBrowserDialog();
            Explorador.SelectedPath = "c:\'";

            String Direccion = null;

            if (Explorador.ShowDialog() == DialogResult.OK)
            {
                Direccion = @Explorador.SelectedPath;
                textBox_descargas.Text = Direccion;
            }
        }
    }
}
