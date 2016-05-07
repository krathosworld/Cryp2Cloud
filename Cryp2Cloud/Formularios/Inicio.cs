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
        //Abre el formulario en el centro de la pantalla
        public inicio()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        //Al darle al botón de iniciar sesión comprueba si el usuario existe en la BD
        //En el caso de existir pasa a la ventana principal, en caso contrario muestra un mensaje de alerta
        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Formularios\MiBaseDeDatos.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From Usuario where id =  '" + textBox_usuario.Text.ToLower() + "'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if(rd.HasRows)
                        {
                            while(rd.Read())
                            {
                                String id = rd["Id"].ToString();
                                String passwd = rd["Contraseña"].ToString();
                                String sal = rd["Sal"].ToString();
                                string hash = Cifrado.obtenerHashCifrado(textBox_contraseña.Text, sal);

                                if(hash.Equals(passwd))
                                {
                                    this.Hide();
                                    Formularios.Principal form = new Formularios.Principal();
                                    form.StartPosition = FormStartPosition.CenterScreen;
                                    form._usuario = textBox_usuario.Text;
                                    form._password = passwd;
                                    form.ShowDialog();
                                    this.Close();
                                }
                            }
                            rd.NextResult();
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario o la contraseña no son correctas","Error",MessageBoxButtons.OK);
                            rd.Close();
                        }
                        
                    }
                    conn.Close();
                }

            }
                
        }

        //Botón que accede al formulario de creación de cuenta
        private void btn_crear_cuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formularios.Registro form = new Formularios.Registro();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            this.Close();
        }




        //--------------------------------------------------------------------------------------------------------------



        //Manejadores de evento para animacione en formulario
        private void textBox_usuario_Enter(object sender, EventArgs e)
        {
            if (textBox_usuario.Text == "Usuario:")
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
            if (textBox_usuario.Text == "")
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

        private void textBox_contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btn_iniciar_sesion.PerformClick();
            }
        }
    }
}
