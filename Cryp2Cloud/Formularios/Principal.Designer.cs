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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.lista_cifrado = new System.Windows.Forms.ComboBox();
            this.btn_ajustes = new System.Windows.Forms.Button();
            this.btn_añadir_archivo = new System.Windows.Forms.Button();
            this.btn_crypt = new System.Windows.Forms.Button();
            this.label_usuario = new System.Windows.Forms.Label();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.Vista_arbol = new GongSolutions.Shell.ShellTreeView();
            this.Vista_carpeta = new GongSolutions.Shell.ShellView();
            this.listaArchivos = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.botonPasar = new System.Windows.Forms.Button();
            this.bt_mega = new System.Windows.Forms.Button();
            this.bt_drive = new System.Windows.Forms.Button();
            this.bt_dropbox = new System.Windows.Forms.Button();
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
            this.lista_cifrado.Text = "AES";
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
            // btn_añadir_archivo
            // 
            this.btn_añadir_archivo.AutoSize = true;
            this.btn_añadir_archivo.BackColor = System.Drawing.Color.Transparent;
            this.btn_añadir_archivo.BackgroundImage = global::Cryp2Cloud.Properties.Resources.añadir_archivos1;
            this.btn_añadir_archivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_añadir_archivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_añadir_archivo.FlatAppearance.BorderSize = 0;
            this.btn_añadir_archivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_añadir_archivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_añadir_archivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_añadir_archivo.ForeColor = System.Drawing.Color.Transparent;
            this.btn_añadir_archivo.Location = new System.Drawing.Point(623, 76);
            this.btn_añadir_archivo.Name = "btn_añadir_archivo";
            this.btn_añadir_archivo.Size = new System.Drawing.Size(245, 38);
            this.btn_añadir_archivo.TabIndex = 2;
            this.btn_añadir_archivo.UseVisualStyleBackColor = false;
            this.btn_añadir_archivo.Click += new System.EventHandler(this.btn_añadir_archivo_Click);
            this.btn_añadir_archivo.MouseEnter += new System.EventHandler(this.btn_añadir_archivo_MouseEnter);
            this.btn_añadir_archivo.MouseLeave += new System.EventHandler(this.btn_añadir_archivo_MouseLeave);
            // 
            // btn_crypt
            // 
            this.btn_crypt.AutoSize = true;
            this.btn_crypt.BackColor = System.Drawing.Color.Transparent;
            this.btn_crypt.BackgroundImage = global::Cryp2Cloud.Properties.Resources.Cifrar2;
            this.btn_crypt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_crypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_crypt.FlatAppearance.BorderSize = 0;
            this.btn_crypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_crypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_crypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crypt.ForeColor = System.Drawing.Color.Transparent;
            this.btn_crypt.Location = new System.Drawing.Point(555, 583);
            this.btn_crypt.Name = "btn_crypt";
            this.btn_crypt.Size = new System.Drawing.Size(180, 25);
            this.btn_crypt.TabIndex = 3;
            this.btn_crypt.UseVisualStyleBackColor = false;
            this.btn_crypt.Click += new System.EventHandler(this.btn_crypt_Click);
            this.btn_crypt.MouseEnter += new System.EventHandler(this.btn_crypt_MouseEnter);
            this.btn_crypt.MouseLeave += new System.EventHandler(this.btn_crypt_MouseLeave);
            // 
            // label_usuario
            // 
            this.label_usuario.BackColor = System.Drawing.Color.Transparent;
            this.label_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_usuario.Location = new System.Drawing.Point(662, 28);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(265, 23);
            this.label_usuario.TabIndex = 4;
            this.label_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.AutoSize = true;
            this.btn_decrypt.BackColor = System.Drawing.Color.Transparent;
            this.btn_decrypt.BackgroundImage = global::Cryp2Cloud.Properties.Resources.Descifrar2;
            this.btn_decrypt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_decrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_decrypt.FlatAppearance.BorderSize = 0;
            this.btn_decrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_decrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_decrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_decrypt.ForeColor = System.Drawing.Color.Transparent;
            this.btn_decrypt.Location = new System.Drawing.Point(753, 583);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(180, 25);
            this.btn_decrypt.TabIndex = 5;
            this.btn_decrypt.UseVisualStyleBackColor = false;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            this.btn_decrypt.MouseEnter += new System.EventHandler(this.btn_decrypt_MouseEnter);
            this.btn_decrypt.MouseLeave += new System.EventHandler(this.btn_decrypt_MouseLeave);
            // 
            // Vista_arbol
            // 
            this.Vista_arbol.BackColor = System.Drawing.SystemColors.Control;
            this.Vista_arbol.Location = new System.Drawing.Point(61, 120);
            this.Vista_arbol.Name = "Vista_arbol";
            this.Vista_arbol.ShellView = this.Vista_carpeta;
            this.Vista_arbol.Size = new System.Drawing.Size(150, 454);
            this.Vista_arbol.TabIndex = 6;
            // 
            // Vista_carpeta
            // 
            this.Vista_carpeta.Location = new System.Drawing.Point(213, 119);
            this.Vista_carpeta.Name = "Vista_carpeta";
            this.Vista_carpeta.Size = new System.Drawing.Size(225, 454);
            this.Vista_carpeta.StatusBar = null;
            this.Vista_carpeta.TabIndex = 7;
            this.Vista_carpeta.Text = "shellView1";
            this.Vista_carpeta.View = GongSolutions.Shell.ShellViewStyle.SmallIcon;
            // 
            // listaArchivos
            // 
            this.listaArchivos.AllowDrop = true;
            this.listaArchivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaArchivos.LargeImageList = this.imageList1;
            this.listaArchivos.Location = new System.Drawing.Point(556, 120);
            this.listaArchivos.Name = "listaArchivos";
            this.listaArchivos.Size = new System.Drawing.Size(377, 456);
            this.listaArchivos.SmallImageList = this.imageList1;
            this.listaArchivos.TabIndex = 8;
            this.listaArchivos.UseCompatibleStateImageBehavior = false;
            this.listaArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.listaArchivos_DragDrop);
            this.listaArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.listaArchivos_DragEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Icon-Document04-Blue.png");
            // 
            // botonPasar
            // 
            this.botonPasar.AutoSize = true;
            this.botonPasar.BackColor = System.Drawing.Color.Transparent;
            this.botonPasar.BackgroundImage = global::Cryp2Cloud.Properties.Resources.crypt_normal;
            this.botonPasar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonPasar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonPasar.FlatAppearance.BorderSize = 0;
            this.botonPasar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonPasar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonPasar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPasar.ForeColor = System.Drawing.Color.Transparent;
            this.botonPasar.Location = new System.Drawing.Point(447, 306);
            this.botonPasar.Name = "botonPasar";
            this.botonPasar.Size = new System.Drawing.Size(100, 100);
            this.botonPasar.TabIndex = 9;
            this.botonPasar.UseVisualStyleBackColor = false;
            this.botonPasar.Click += new System.EventHandler(this.botonPasar_Click);
            this.botonPasar.MouseEnter += new System.EventHandler(this.botonPasar_MouseEnter);
            this.botonPasar.MouseLeave += new System.EventHandler(this.botonPasar_MouseLeave);
            // 
            // bt_mega
            // 
            this.bt_mega.AutoSize = true;
            this.bt_mega.BackColor = System.Drawing.Color.Transparent;
            this.bt_mega.BackgroundImage = global::Cryp2Cloud.Properties.Resources.unnamed;
            this.bt_mega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_mega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_mega.FlatAppearance.BorderSize = 0;
            this.bt_mega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_mega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_mega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mega.ForeColor = System.Drawing.Color.Transparent;
            this.bt_mega.Location = new System.Drawing.Point(381, 78);
            this.bt_mega.Name = "bt_mega";
            this.bt_mega.Size = new System.Drawing.Size(30, 30);
            this.bt_mega.TabIndex = 10;
            this.bt_mega.UseVisualStyleBackColor = false;
            this.bt_mega.Click += new System.EventHandler(this.bt_mega_Click);
            // 
            // bt_drive
            // 
            this.bt_drive.AutoSize = true;
            this.bt_drive.BackColor = System.Drawing.Color.Transparent;
            this.bt_drive.BackgroundImage = global::Cryp2Cloud.Properties.Resources.Google_Drive_icon;
            this.bt_drive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_drive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_drive.FlatAppearance.BorderSize = 0;
            this.bt_drive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_drive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_drive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_drive.ForeColor = System.Drawing.Color.Transparent;
            this.bt_drive.Location = new System.Drawing.Point(308, 78);
            this.bt_drive.Name = "bt_drive";
            this.bt_drive.Size = new System.Drawing.Size(30, 30);
            this.bt_drive.TabIndex = 11;
            this.bt_drive.UseVisualStyleBackColor = false;
            this.bt_drive.Click += new System.EventHandler(this.bt_drive_Click);
            // 
            // bt_dropbox
            // 
            this.bt_dropbox.AutoSize = true;
            this.bt_dropbox.BackColor = System.Drawing.Color.Transparent;
            this.bt_dropbox.BackgroundImage = global::Cryp2Cloud.Properties.Resources.dropbox_xxl;
            this.bt_dropbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_dropbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_dropbox.FlatAppearance.BorderSize = 0;
            this.bt_dropbox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_dropbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_dropbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_dropbox.ForeColor = System.Drawing.Color.Transparent;
            this.bt_dropbox.Location = new System.Drawing.Point(235, 78);
            this.bt_dropbox.Name = "bt_dropbox";
            this.bt_dropbox.Size = new System.Drawing.Size(30, 30);
            this.bt_dropbox.TabIndex = 12;
            this.bt_dropbox.UseVisualStyleBackColor = false;
            this.bt_dropbox.Click += new System.EventHandler(this.bt_dropbox_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(992, 645);
            this.Controls.Add(this.bt_dropbox);
            this.Controls.Add(this.bt_drive);
            this.Controls.Add(this.bt_mega);
            this.Controls.Add(this.botonPasar);
            this.Controls.Add(this.listaArchivos);
            this.Controls.Add(this.Vista_carpeta);
            this.Controls.Add(this.Vista_arbol);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.label_usuario);
            this.Controls.Add(this.btn_crypt);
            this.Controls.Add(this.btn_añadir_archivo);
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
        private System.Windows.Forms.Button btn_añadir_archivo;
        private System.Windows.Forms.Button btn_crypt;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Button btn_decrypt;
        private GongSolutions.Shell.ShellTreeView Vista_arbol;
        private GongSolutions.Shell.ShellView Vista_carpeta;
        private System.Windows.Forms.ListView listaArchivos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button botonPasar;
        private System.Windows.Forms.Button bt_mega;
        private System.Windows.Forms.Button bt_drive;
        private System.Windows.Forms.Button bt_dropbox;
    }
}