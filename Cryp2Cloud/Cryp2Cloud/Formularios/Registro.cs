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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            
            //Cambiar la ventana
            this.Hide();
            Formularios.Principal form = new Formularios.Principal();
            form.ShowDialog();
            this.Close();
        }



        //LANZADORES DE EVENTOS
        private void btn_acceder_MouseEnter(object sender, EventArgs e)
        {
            btn_acceder.BackgroundImage = Cryp2Cloud.Properties.Resources.Acceder2;
        }

        private void btn_acceder_MouseLeave(object sender, EventArgs e)
        {
            btn_acceder.BackgroundImage = Cryp2Cloud.Properties.Resources.Acceder1;
        }

        private void limpiar_casilla(object sender)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
        }

        private void textBox_usuario_Enter(object sender, EventArgs e)
        {
            if (textBox_usuario.Text == "Usuario:")
            {
                limpiar_casilla(sender);
            }
        }

        private void textBox_contraseña_Enter(object sender, EventArgs e)
        {
            limpiar_casilla(sender);
            textBox_contraseña.PasswordChar = '*';
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
                limpiar_casilla(sender);
                textBox1.PasswordChar = '*';
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.PasswordChar = '\0';
                textBox1.Text = "Repetir Contraseña:";
            }
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
    }
}
