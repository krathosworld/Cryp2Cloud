using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cryp2Cloud
{
    public partial class inicio : Form
    {
        public inicio()
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void textBox_usuario_Enter(object sender, EventArgs e)
        {
            if(textBox_usuario.Text=="Usuario:")
            {
                limpiar_casilla(sender);
            }
        }
        private void limpiar_casilla(object sender)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
        }

        private void textBox_contraseña_Enter(object sender, EventArgs e)
        {
            limpiar_casilla(sender);
            textBox_contraseña.PasswordChar = '*';
        }

        private void btn_iniciar_sesion_MouseEnter(object sender, EventArgs e)
        {
            btn_iniciar_sesion.BackgroundImage = Cryp2Cloud.Properties.Resources.Iniciar_sesion2;
        }

        private void btn_iniciar_sesion_MouseLeave(object sender, EventArgs e)
        {
            btn_iniciar_sesion.BackgroundImage = Cryp2Cloud.Properties.Resources.Iniciar_sesion1;
        }

        private void textBox_usuario_Leave(object sender, EventArgs e)
        {
            if(textBox_usuario.Text=="")
            {
                textBox_usuario.Text = "Usuario:";
            }
        }

        private void textBox_contraseña_Leave(object sender, EventArgs e)
        {
            if (textBox_contraseña.Text == "")
            {
                textBox_contraseña.PasswordChar = '\0';
                textBox_contraseña.Text = "Contraseña:";
            }
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Formularios\MiBaseDeDatos.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From Usuario", conn))
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        MessageBox.Show("Esto va bien");
                    }
                }

            }
                
            this.Hide();
            Formularios.Principal form = new Formularios.Principal();
            form.ShowDialog();
            this.Close();
        }

        private void btn_crear_cuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formularios.Registro form = new Formularios.Registro();
            form.Location = this.Location;
            form.ShowDialog();
            this.Close();
        }
    }
}
