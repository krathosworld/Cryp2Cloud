namespace Cryp2Cloud
{
    partial class inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inicio));
            this.btn_iniciar_sesion = new System.Windows.Forms.Button();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_contraseña = new System.Windows.Forms.TextBox();
            this.btn_crear_cuenta = new System.Windows.Forms.Button();
            this.ListaImagenes = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btn_iniciar_sesion
            // 
            this.btn_iniciar_sesion.AutoSize = true;
            this.btn_iniciar_sesion.BackColor = System.Drawing.Color.Transparent;
            this.btn_iniciar_sesion.BackgroundImage = global::Cryp2Cloud.Properties.Resources.Iniciar_sesion1;
            this.btn_iniciar_sesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_iniciar_sesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_iniciar_sesion.FlatAppearance.BorderSize = 0;
            this.btn_iniciar_sesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_iniciar_sesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_iniciar_sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iniciar_sesion.ForeColor = System.Drawing.Color.Transparent;
            this.btn_iniciar_sesion.Location = new System.Drawing.Point(32, 522);
            this.btn_iniciar_sesion.Name = "btn_iniciar_sesion";
            this.btn_iniciar_sesion.Size = new System.Drawing.Size(388, 50);
            this.btn_iniciar_sesion.TabIndex = 0;
            this.btn_iniciar_sesion.UseVisualStyleBackColor = false;
            this.btn_iniciar_sesion.Click += new System.EventHandler(this.btn_iniciar_sesion_Click);
            this.btn_iniciar_sesion.MouseEnter += new System.EventHandler(this.btn_iniciar_sesion_MouseEnter);
            this.btn_iniciar_sesion.MouseLeave += new System.EventHandler(this.btn_iniciar_sesion_MouseLeave);
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_usuario.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_usuario.Location = new System.Drawing.Point(41, 420);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(367, 28);
            this.textBox_usuario.TabIndex = 1;
            this.textBox_usuario.Text = "Usuario:";
            this.textBox_usuario.Enter += new System.EventHandler(this.textBox_usuario_Enter);
            this.textBox_usuario.Leave += new System.EventHandler(this.textBox_usuario_Leave);
            // 
            // textBox_contraseña
            // 
            this.textBox_contraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_contraseña.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_contraseña.Location = new System.Drawing.Point(41, 468);
            this.textBox_contraseña.Name = "textBox_contraseña";
            this.textBox_contraseña.Size = new System.Drawing.Size(367, 28);
            this.textBox_contraseña.TabIndex = 2;
            this.textBox_contraseña.Text = "Contraseña:";
            this.textBox_contraseña.Enter += new System.EventHandler(this.textBox_contraseña_Enter);
            this.textBox_contraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_contraseña_KeyDown);
            this.textBox_contraseña.Leave += new System.EventHandler(this.textBox_contraseña_Leave);
            // 
            // btn_crear_cuenta
            // 
            this.btn_crear_cuenta.AutoSize = true;
            this.btn_crear_cuenta.BackColor = System.Drawing.Color.Transparent;
            this.btn_crear_cuenta.BackgroundImage = global::Cryp2Cloud.Properties.Resources.crear_cuenta;
            this.btn_crear_cuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_crear_cuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_crear_cuenta.FlatAppearance.BorderSize = 0;
            this.btn_crear_cuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_crear_cuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_crear_cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crear_cuenta.ForeColor = System.Drawing.Color.Transparent;
            this.btn_crear_cuenta.Location = new System.Drawing.Point(32, 583);
            this.btn_crear_cuenta.Name = "btn_crear_cuenta";
            this.btn_crear_cuenta.Size = new System.Drawing.Size(388, 50);
            this.btn_crear_cuenta.TabIndex = 3;
            this.btn_crear_cuenta.UseVisualStyleBackColor = false;
            this.btn_crear_cuenta.Click += new System.EventHandler(this.btn_crear_cuenta_Click);
            // 
            // ListaImagenes
            // 
            this.ListaImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListaImagenes.ImageStream")));
            this.ListaImagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.ListaImagenes.Images.SetKeyName(0, "crear_cuenta");
            this.ListaImagenes.Images.SetKeyName(1, "Iniciar_sesion1");
            this.ListaImagenes.Images.SetKeyName(2, "iniciar_sesion2");
            // 
            // inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(452, 645);
            this.Controls.Add(this.btn_crear_cuenta);
            this.Controls.Add(this.textBox_contraseña);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.btn_iniciar_sesion);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(468, 684);
            this.MinimumSize = new System.Drawing.Size(468, 684);
            this.Name = "inicio";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.Text = "Cryp2Cloud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_iniciar_sesion;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_contraseña;
        private System.Windows.Forms.Button btn_crear_cuenta;
        private System.Windows.Forms.ImageList ListaImagenes;
    }
}

