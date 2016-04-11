namespace Cryp2Cloud.Formularios
{
    partial class Registro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.btn_acceder = new System.Windows.Forms.Button();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_contraseña = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_acceder
            // 
            this.btn_acceder.AutoSize = true;
            this.btn_acceder.BackColor = System.Drawing.Color.Transparent;
            this.btn_acceder.BackgroundImage = global::Cryp2Cloud.Properties.Resources.Acceder1;
            this.btn_acceder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_acceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_acceder.FlatAppearance.BorderSize = 0;
            this.btn_acceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_acceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_acceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_acceder.ForeColor = System.Drawing.Color.Transparent;
            this.btn_acceder.Location = new System.Drawing.Point(32, 569);
            this.btn_acceder.Name = "btn_acceder";
            this.btn_acceder.Size = new System.Drawing.Size(388, 50);
            this.btn_acceder.TabIndex = 1;
            this.btn_acceder.UseVisualStyleBackColor = false;
            this.btn_acceder.Click += new System.EventHandler(this.btn_acceder_Click);
            this.btn_acceder.MouseEnter += new System.EventHandler(this.btn_acceder_MouseEnter);
            this.btn_acceder.MouseLeave += new System.EventHandler(this.btn_acceder_MouseLeave);
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_usuario.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_usuario.Location = new System.Drawing.Point(43, 420);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(367, 28);
            this.textBox_usuario.TabIndex = 2;
            this.textBox_usuario.Text = "Usuario:";
            this.textBox_usuario.Enter += new System.EventHandler(this.textBox_usuario_Enter);
            this.textBox_usuario.Leave += new System.EventHandler(this.textBox_usuario_Leave);
            // 
            // textBox_contraseña
            // 
            this.textBox_contraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_contraseña.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_contraseña.Location = new System.Drawing.Point(43, 467);
            this.textBox_contraseña.Name = "textBox_contraseña";
            this.textBox_contraseña.Size = new System.Drawing.Size(367, 28);
            this.textBox_contraseña.TabIndex = 3;
            this.textBox_contraseña.Text = "Contraseña:";
            this.textBox_contraseña.Enter += new System.EventHandler(this.textBox_contraseña_Enter);
            this.textBox_contraseña.Leave += new System.EventHandler(this.textBox_contraseña_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox1.Location = new System.Drawing.Point(43, 519);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 28);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Repetir Contraseña:";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(452, 645);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_contraseña);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.btn_acceder);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(468, 684);
            this.MinimumSize = new System.Drawing.Size(468, 684);
            this.Name = "Registro";
            this.Opacity = 0.98D;
            this.Text = "Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_acceder;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_contraseña;
        private System.Windows.Forms.TextBox textBox1;
    }
}