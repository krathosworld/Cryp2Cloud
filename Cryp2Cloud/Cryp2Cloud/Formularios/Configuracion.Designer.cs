namespace Cryp2Cloud.Formularios
{
    partial class Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            this.textBox_dropbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_dropbox
            // 
            this.textBox_dropbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_dropbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_dropbox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_dropbox.Location = new System.Drawing.Point(72, 236);
            this.textBox_dropbox.Name = "textBox_dropbox";
            this.textBox_dropbox.Size = new System.Drawing.Size(272, 17);
            this.textBox_dropbox.TabIndex = 2;
            this.textBox_dropbox.Text = "Ruta de dropbox";
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(452, 645);
            this.Controls.Add(this.textBox_dropbox);
            this.MaximizeBox = false;
            this.Name = "Configuracion";
            this.Opacity = 0.98D;
            this.Text = "Configuracion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_dropbox;
    }
}