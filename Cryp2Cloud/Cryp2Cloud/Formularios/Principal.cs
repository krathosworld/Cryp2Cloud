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
    public partial class Principal: Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void btn_ajustes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formularios.Configuracion form = new Formularios.Configuracion();
            form.ShowDialog();
            this.Close();
        }
    }
}
