using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cryp2Cloud.Formularios
{
    public partial class Configuracion : Form
    {
        //Ruta por defecto del usuario
        static string raiz = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        //Persistencia de datos de usuario
        public String _usuario = null;

        BigCheckBox check_dropbox = new BigCheckBox(405, 232, "check_dropbox");
        BigCheckBox check_drive = new BigCheckBox(405, 314, "check_drive");
        BigCheckBox check_mega = new BigCheckBox(405, 400, "check_mega");

        public Configuracion()
        {
            this.Controls.Add(check_dropbox);
            this.Controls.Add(check_drive);
            this.Controls.Add(check_mega);
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            InitializeComponent();
        }

        class BigCheckBox : CheckBox
        {
            public BigCheckBox(int x, int y, string nombre)
            {
                this.Text = "\0";
                this.TextAlign = ContentAlignment.MiddleRight;
                this.Location = new Point(x, y);
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
            if(!check_dropbox.Checked && !check_drive.Checked && !check_mega.Checked)
            {
                MessageBox.Show("Debe seleccionar un servicio");
            }
            else
            {
                this.Hide();
                this.Close();
            }
        }

        private void btn_explorar_dropbox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Explorador = new FolderBrowserDialog();
            Explorador.SelectedPath = "c:\'";

            String Direccion = null;

            if (Explorador.ShowDialog() == DialogResult.OK)
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

        private void Configuracion_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Formularios\MiBaseDeDatos.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From Usuario where id =  '" + _usuario + "'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                           //Cargamos todos los datos de la BBDD
                            Boolean drive = Convert.ToBoolean(rd["CheckDrive"]);
                            Boolean mega = Convert.ToBoolean(rd["CheckMega"]);
                            Boolean dropbox = Convert.ToBoolean(rd["CheckDropbox"]);
                            String DirDrive = rd["DirDrive"].ToString();
                            String DirMega = rd["DirMega"].ToString();
                            String DirDropbox = rd["DirDropbox"].ToString();
                            String DirDefault = rd["DirDefault"].ToString();

                            //Llamamaos a una función que nos rellena los campos a partir de los datos obtenidos
                            RellenarCampos(drive, mega, dropbox, DirDrive, DirMega, DirDropbox, DirDefault);
                        }
                        rd.NextResult();
                    }
                    conn.Close();
                }

            }
        }
        private void RellenarCampos(Boolean drive,Boolean mega,Boolean dropbox,String DirDrive,String DirMega,String DirDropbox,String DirDefault)
        {
            check_dropbox.Checked = dropbox;
            check_drive.Checked = drive;
            check_mega.Checked = mega;

            if (DirDrive == "")
            {
                //Ruta por defecto para drive
                string drivePath = raiz + "\\Drive";
                textBox_drive.Text = drivePath;
            }
            else textBox_drive.Text = DirDrive;

            if (DirDropbox == "")
            {
                //Ruta por defecto para dropbox
                string dropPath = raiz + "\\Dropbox";
                textBox_dropbox.Text = dropPath;
            }
            else textBox_dropbox.Text = DirDropbox;

            if (DirMega == "")
            {
                //Ruta por defecto para mega
                string megaPath = raiz + "\\MegaAsync";
                textBox_mega.Text = megaPath;
            }
            else textBox_mega.Text = DirMega;

            if (DirDefault == "")
            {
                //Ruta por defecto para las descargas
                //Ruta de descargas
                string downloadPath = raiz + "\\Downloads";

                textBox_descargas.Text = downloadPath;
            }
            else textBox_descargas.Text = DirDefault;

        }
    }
}