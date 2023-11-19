namespace Gestion_employés
{
    partial class Authentif_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentif_Admin));
            this.Autentif_Adm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.Conn_Adm = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.ESP_admin = new System.Windows.Forms.Button();
            this.ESP_employe = new System.Windows.Forms.Button();
            this.Autentif_Adm.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // Autentif_Adm
            // 
            this.Autentif_Adm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Autentif_Adm.BackgroundImage = global::Gestion_employés.Properties.Resources.b;
            this.Autentif_Adm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Autentif_Adm.Controls.Add(this.label1);
            this.Autentif_Adm.Controls.Add(this.label73);
            this.Autentif_Adm.Controls.Add(this.panel9);
            this.Autentif_Adm.Location = new System.Drawing.Point(0, 38);
            this.Autentif_Adm.Name = "Autentif_Adm";
            this.Autentif_Adm.Size = new System.Drawing.Size(1305, 682);
            this.Autentif_Adm.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::Gestion_employés.Properties.Resources.ily;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(963, 645);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 37);
            this.label1.TabIndex = 54;
            this.label1.Text = "Created By ILYAS MAKHLOUL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Image = global::Gestion_employés.Properties.Resources.login;
            this.label73.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label73.Location = new System.Drawing.Point(481, 38);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(312, 56);
            this.label73.TabIndex = 53;
            this.label73.Text = "S\'authentifié    ";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel9.Controls.Add(this.Conn_Adm);
            this.panel9.Controls.Add(this.Password);
            this.panel9.Controls.Add(this.UserName);
            this.panel9.Controls.Add(this.label72);
            this.panel9.Controls.Add(this.label71);
            this.panel9.Location = new System.Drawing.Point(386, 152);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(519, 409);
            this.panel9.TabIndex = 0;
            // 
            // Conn_Adm
            // 
            this.Conn_Adm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Conn_Adm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Conn_Adm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conn_Adm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Conn_Adm.Location = new System.Drawing.Point(166, 279);
            this.Conn_Adm.Name = "Conn_Adm";
            this.Conn_Adm.Size = new System.Drawing.Size(210, 51);
            this.Conn_Adm.TabIndex = 28;
            this.Conn_Adm.Text = "Se connecter";
            this.Conn_Adm.UseVisualStyleBackColor = false;
            this.Conn_Adm.Click += new System.EventHandler(this.Conn_Adm_Click);
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(287, 161);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '.';
            this.Password.Size = new System.Drawing.Size(192, 53);
            this.Password.TabIndex = 27;
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(287, 67);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(192, 34);
            this.UserName.TabIndex = 26;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Perpetua", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label72.Location = new System.Drawing.Point(41, 162);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(149, 38);
            this.label72.TabIndex = 25;
            this.label72.Text = "Mot de passe";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Perpetua", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label71.Location = new System.Drawing.Point(36, 64);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(205, 38);
            this.label71.TabIndex = 24;
            this.label71.Text = "Nom d\'utilisateur";
            // 
            // ESP_admin
            // 
            this.ESP_admin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ESP_admin.FlatAppearance.BorderSize = 0;
            this.ESP_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ESP_admin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.ESP_admin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ESP_admin.Image = global::Gestion_employés.Properties.Resources.adm;
            this.ESP_admin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ESP_admin.Location = new System.Drawing.Point(1, 0);
            this.ESP_admin.Name = "ESP_admin";
            this.ESP_admin.Size = new System.Drawing.Size(312, 42);
            this.ESP_admin.TabIndex = 8;
            this.ESP_admin.Text = "Espace Administrateur ";
            this.ESP_admin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ESP_admin.UseVisualStyleBackColor = false;
            this.ESP_admin.Click += new System.EventHandler(this.ESP_admin_Click);
            // 
            // ESP_employe
            // 
            this.ESP_employe.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ESP_employe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ESP_employe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.ESP_employe.Image = global::Gestion_employés.Properties.Resources.work;
            this.ESP_employe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ESP_employe.Location = new System.Drawing.Point(335, 0);
            this.ESP_employe.Name = "ESP_employe";
            this.ESP_employe.Size = new System.Drawing.Size(967, 42);
            this.ESP_employe.TabIndex = 6;
            this.ESP_employe.Text = "Esapce Employé";
            this.ESP_employe.UseVisualStyleBackColor = false;
            this.ESP_employe.Click += new System.EventHandler(this.ESP_employe_Click);
            // 
            // Authentif_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 722);
            this.Controls.Add(this.Autentif_Adm);
            this.Controls.Add(this.ESP_admin);
            this.Controls.Add(this.ESP_employe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Authentif_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentifiction Administrateur";
            this.Autentif_Adm.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ESP_admin;
        private System.Windows.Forms.Button ESP_employe;
        private System.Windows.Forms.Panel Autentif_Adm;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button Conn_Adm;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label1;
    }
}