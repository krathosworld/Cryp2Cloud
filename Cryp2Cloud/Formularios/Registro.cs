﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cryp2Cloud.Formularios
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        //Al adarle a acceder primero comprueba que todos los datos hayan sido rellenados correctamente y luego comprueba con la base de datos
        //En el caso de ser todo correcto cambiará a la ventana principal, en caso contrario monstrará un mensaje de error.
        private void btn_acceder_Click(object sender, EventArgs e)
        {
            if (comprobaciones())
            {
                connBBDD();
            }
        }

        //Realiza las comprobaciones sobre los campos a rellenar
        //devuelve true en caso de estar todo correcto, false en caso de fallar
        private bool comprobaciones()
        {
            bool resultado = true;
            String errores = "Ha habido algun error:\n\n";
            String usuario = textBox_usuario.Text;
            String contraseña = textBox_contraseña.Text;
            String repContraseña = textBox1.Text;

            if (usuario == "Usuario:" || contraseña == "Contraseña:" || repContraseña == "Repetir Contraseña:")
            {
                errores += "Debe rellenar todos los campos\n";
                resultado = false;
            }
            else if (contraseña != repContraseña)
            {
                errores += "Las contraseñas no coinciden\n";
                resultado = false;
            }

            if (usuario.Length > 16)
            {
                errores += "El nombre de usuario no puede tener más de 16 caracteres\n";
                resultado = false;
            }
            if (contraseña.Length > 16)
            {
                errores += "La contraseña no puede tener más de 16 caracteres\n";
                resultado = false;
            }


            if (!resultado) //Si ha habido algún fallo
            {
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK);
            }
            else if(contraseña.Length < 8) //Si no ha habido ningun fallo pero la contraseña es muy corta
            {
                if(MessageBox.Show("La contraseña es demasiado corta, le recomendamos que utilice una contraseña de al menos 8 dígitos \n ¿Desea seguir de todos modos?","Aviso",MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        //Realiza la conexión con la BBDD, en caso de fallar muestra un mensaje de error por pantalla
        //Si se realiza correctamente la inserción se cambia a la ventana principal junto con la de configuración
        private void connBBDD()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Formularios\MiBaseDeDatos.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From Usuario where id =  '" + textBox_usuario.Text.ToLower() + "'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            MessageBox.Show("Error: El usuario ya existe", "Error", MessageBoxButtons.OK);
                            rd.Close();
                        }
                        else
                        {
                            rd.Close();

                            //Inicializamos el DataSet que conecta con la tabla usuarios
                            BBDDDataSetTableAdapters.UsuarioTableAdapter usuarioTableAdapter;
                            usuarioTableAdapter = new BBDDDataSetTableAdapters.UsuarioTableAdapter();
                            String usuario = textBox_usuario.Text.ToLower();
                            String contraseña = textBox_contraseña.Text;
                            String sal = Cifrado.CrearClaveAleatoria(32);
                            String hash = Cifrado.obtenerHashCifrado(contraseña, sal);

                            //Insertamos el nuevo usuario en la base de datos
                            usuarioTableAdapter.Insert(usuario, hash, null, null, null, null, false, false, false,sal);

                            this.Hide();
                            Formularios.Principal form = new Formularios.Principal();
                            Formularios.Configuracion form2 = new Formularios.Configuracion();

                            form.StartPosition = FormStartPosition.CenterScreen;
                            form2.StartPosition= FormStartPosition.CenterScreen;

                            //Cargamos el usuario en el resto de formularios
                            form._usuario = usuario;
                            form2._usuario = usuario;
                            form._password = hash;
                            form2._principal = form;
                            try
                            {
                                form2.ShowDialog();
                                form.ShowDialog();
                            }
                            catch(System.NullReferenceException)
                            {

                            }
                            this.Close();
                        }
                    }

                    conn.Close();
                }
            }

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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_acceder.PerformClick();
            }
        }
    }
}