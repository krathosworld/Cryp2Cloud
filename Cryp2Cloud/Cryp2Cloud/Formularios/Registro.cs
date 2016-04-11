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
            this.Hide();
            Formularios.Principal form = new Formularios.Principal();
            form.ShowDialog();
            this.Close();
        }

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

    }
}
