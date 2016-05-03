using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cryp2Cloud.Formularios
{
    public partial class Configuracion : Form
    {
        //Ruta por defecto del usuario
        static string raiz = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        //Persistencia de datos de usuario
        public String _usuario = null;
        public Formularios.Principal _principal = null; //Sirve para actualizar los datos en la ventana principal

        //Booleano para determinar si el formulario se abre por primera vez
        Boolean PrimeraVez = false;

        //Iniciamos las checkbox personalizadas
        BigCheckBox check_dropbox = new BigCheckBox(405, 232, "check_dropbox");
        BigCheckBox check_drive = new BigCheckBox(405, 314, "check_drive");
        BigCheckBox check_mega = new BigCheckBox(405, 400, "check_mega");

        //Añade los checkboxs personalizados a la pantalla e inicializa los componentes
        public Configuracion()
        {
            this.Controls.Add(check_dropbox);
            this.Controls.Add(check_drive);
            this.Controls.Add(check_mega);
            InitializeComponent();
        }

        //Este manejador de evento se emplea cada vez que el formulario se va a cerrar
        //Comprueba si el formulario ha sido abierto por primera vez, en caso de ser así no te deja cerrarlo hasta guardar cambios
        private void Configuracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PrimeraVez)
            {
                MessageBox.Show("Debe guardar los cambios al menos una vez");
                e.Cancel = true;
            }

        }

        //Al abrirse la ventana de configuración de cargan de la base de datos los datos del usuario
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

                            //Llamamos a una función que nos rellena los campos a partir de los datos obtenidos
                            RellenarCampos(drive, mega, dropbox, DirDrive, DirMega, DirDropbox, DirDefault);
                        }
                        rd.NextResult();
                    }
                    conn.Close();
                }

            }
        }


        //Botón acceder, comprueba si los datos introducirlos son válidos, de serlo guarda los datos en la BBDD
        //En caso contrario muestra un mensaje informando del error producido
        private void btn_acceder_Click(object sender, EventArgs e)
        {
            if(!check_dropbox.Checked && !check_drive.Checked && !check_mega.Checked)
            {
                MessageBox.Show("Debe seleccionar un servicio");
            }
            else if(!Directory.Exists(textBox_descargas.Text)) //Comprueba que la ruta especificada exista en el ordenador
            {
                MessageBox.Show("La ruta de descargas no es válida, por favor introdúzcala de nuevo");
            }
            else if (!Directory.Exists(textBox_drive.Text) && check_drive.Checked) //Comprueba que la ruta especificada exista en el ordenador (Sólo si ésta ha sido seleccionada)
            {
                MessageBox.Show("La ruta de drive no es válida, por favor introdúzcala de nuevo");
            }
            else if (!Directory.Exists(textBox_dropbox.Text) && check_dropbox.Checked) //Comprueba que la ruta especificada exista en el ordenador (Sólo si ésta ha sido seleccionada)
            {
                MessageBox.Show("La ruta de dropbox no es válida, por favor introdúzcala de nuevo");
            }
            else if (!Directory.Exists(textBox_mega.Text) && check_mega.Checked) //Comprueba que la ruta especificada exista en el ordenador (Sólo si ésta ha sido seleccionada)
            {
                MessageBox.Show("La ruta de mega no es válida, por favor introdúzcala de nuevo");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Formularios\MiBaseDeDatos.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Usuario SET [DirDropbox]=@dirDropbox2, [DirDrive]=@dirDrive2, [DirMega]=@dirMega2, [DirDefault]=@dirDefault2, [CheckMega]=@checkMega2, [CheckDropbox]=@checkDropbox2, [CheckDrive] = @checkDrive2 where id = @usuario2", conn))
                    {
                        cmd.Parameters.AddWithValue("@dirDropbox2", textBox_dropbox.Text);
                        cmd.Parameters.AddWithValue("@dirDrive2", textBox_drive.Text);
                        cmd.Parameters.AddWithValue("@dirMega2", textBox_mega.Text);
                        cmd.Parameters.AddWithValue("@dirDefault2", textBox_descargas.Text);
                        cmd.Parameters.AddWithValue("@checkMega2", check_mega.Checked);
                        cmd.Parameters.AddWithValue("@checkDropbox2", check_dropbox.Checked);
                        cmd.Parameters.AddWithValue("@checkDrive2", check_drive.Checked);
                        cmd.Parameters.AddWithValue("@usuario2", _usuario);

                       try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            //Modificar las variables locales de Principal que se vayan a necesitar
                            _principal._checkDrive = check_drive.Checked;
                            _principal._checkDrop = check_dropbox.Checked;
                            _principal._checkMega = check_mega.Checked;
                            _principal._dirDrive = textBox_drive.Text;
                            _principal._dirDrop = textBox_dropbox.Text;
                            _principal._dirMega = textBox_mega.Text;
                            _principal._dir_descarga = textBox_descargas.Text;
                            PrimeraVez = false;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se ha podido conectar con la base de datos");
                            conn.Close();
                        }
                        
                    }

                }
            }
        }

        //Función que rellena los campos del formulario con los datos obtenidos del usuario de la BD
        private void RellenarCampos(Boolean drive, Boolean mega, Boolean dropbox, String DirDrive, String DirMega, String DirDropbox, String DirDefault)
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

                PrimeraVez = true;
            }
            else textBox_descargas.Text = DirDefault;

        }

        //Botones de exploración, abren una ventana de exploración de ficheros
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
        



        //----------------------------------------------------------------------------------------------



        //Clase heredada de CheckBox que crea casillas más grandes
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

        //Lanzadores de evento para animaciones en formulario
        private void btn_acceder_MouseEnter(object sender, EventArgs e)
        {
            btn_acceder.BackgroundImage = Cryp2Cloud.Properties.Resources.Guardar_cambios2;
        }

        private void btn_acceder_MouseLeave(object sender, EventArgs e)
        {
            btn_acceder.BackgroundImage = Cryp2Cloud.Properties.Resources.Guardar_cambios1;
        }
    }
}