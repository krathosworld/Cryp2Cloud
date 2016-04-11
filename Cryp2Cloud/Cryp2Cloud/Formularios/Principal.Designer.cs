namespace Cryp2Cloud.Formularios
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.lista_cifrado = new System.Windows.Forms.ComboBox();
            this.btn_ajustes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lista_cifrado
            // 
            this.lista_cifrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lista_cifrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_cifrado.FormattingEnabled = true;
            this.lista_cifrado.Items.AddRange(new object[] {
            "AES",
            "RC4"});
            this.lista_cifrado.Location = new System.Drawing.Point(62, 588);
            this.lista_cifrado.Name = "lista_cifrado";
            this.lista_cifrado.Size = new System.Drawing.Size(143, 26);
            this.lista_cifrado.TabIndex = 0;
            this.lista_cifrado.Text = "Tipo de Cifrado";
            // 
            // btn_ajustes
            // 
            this.btn_ajustes.AutoSize = true;
            this.btn_ajustes.BackColor = System.Drawing.Color.Transparent;
            this.btn_ajustes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ajustes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ajustes.FlatAppearance.BorderSize = 0;
            this.btn_ajustes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ajustes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ajustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ajustes.ForeColor = System.Drawing.Color.Transparent;
            this.btn_ajustes.Location = new System.Drawing.Point(933, 21);
            this.btn_ajustes.Name = "btn_ajustes";
            this.btn_ajustes.Size = new System.Drawing.Size(35, 35);
            this.btn_ajustes.TabIndex = 1;
            this.btn_ajustes.UseVisualStyleBackColor = false;
            this.btn_ajustes.Click += new System.EventHandler(this.btn_ajustes_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(992, 645);
            this.Controls.Add(this.btn_ajustes);
            this.Controls.Add(this.lista_cifrado);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1008, 684);
            this.MinimumSize = new System.Drawing.Size(1008, 684);
            this.Name = "Principal";
            this.Opacity = 0.98D;
            this.Text = "Cryp2Cloud";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lista_cifrado;
        private System.Windows.Forms.Button btn_ajustes;
    }
}