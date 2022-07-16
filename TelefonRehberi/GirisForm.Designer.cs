
namespace TelefonRehberi
{
    partial class GirisForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxProfilResmi = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxKullaniciGirisBilgileri = new System.Windows.Forms.GroupBox();
            this.buttonSistemGiris = new System.Windows.Forms.Button();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxProfilResmi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxKullaniciGirisBilgileri.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProfilResmi
            // 
            this.groupBoxProfilResmi.Controls.Add(this.pictureBox1);
            this.groupBoxProfilResmi.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProfilResmi.Name = "groupBoxProfilResmi";
            this.groupBoxProfilResmi.Size = new System.Drawing.Size(299, 361);
            this.groupBoxProfilResmi.TabIndex = 0;
            this.groupBoxProfilResmi.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TelefonRehberi.Properties.Resources.user_icon;
            this.pictureBox1.Location = new System.Drawing.Point(6, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxKullaniciGirisBilgileri
            // 
            this.groupBoxKullaniciGirisBilgileri.Controls.Add(this.buttonSistemGiris);
            this.groupBoxKullaniciGirisBilgileri.Controls.Add(this.textBoxSifre);
            this.groupBoxKullaniciGirisBilgileri.Controls.Add(this.textBoxKullaniciAdi);
            this.groupBoxKullaniciGirisBilgileri.Controls.Add(this.label2);
            this.groupBoxKullaniciGirisBilgileri.Controls.Add(this.label1);
            this.groupBoxKullaniciGirisBilgileri.Location = new System.Drawing.Point(317, 23);
            this.groupBoxKullaniciGirisBilgileri.Name = "groupBoxKullaniciGirisBilgileri";
            this.groupBoxKullaniciGirisBilgileri.Size = new System.Drawing.Size(587, 371);
            this.groupBoxKullaniciGirisBilgileri.TabIndex = 0;
            this.groupBoxKullaniciGirisBilgileri.TabStop = false;
            this.groupBoxKullaniciGirisBilgileri.Text = "Kullanici Giris Bilgileri";
            this.groupBoxKullaniciGirisBilgileri.Enter += new System.EventHandler(this.groupBoxKullaniciGirisBilgileri_Enter);
            // 
            // buttonSistemGiris
            // 
            this.buttonSistemGiris.Location = new System.Drawing.Point(46, 197);
            this.buttonSistemGiris.Name = "buttonSistemGiris";
            this.buttonSistemGiris.Size = new System.Drawing.Size(541, 41);
            this.buttonSistemGiris.TabIndex = 2;
            this.buttonSistemGiris.Text = "Giris";
            this.buttonSistemGiris.UseVisualStyleBackColor = true;
            this.buttonSistemGiris.Click += new System.EventHandler(this.buttonSistemGiris_Click);
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSifre.Location = new System.Drawing.Point(204, 121);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.PasswordChar = '*';
            this.textBoxSifre.Size = new System.Drawing.Size(366, 39);
            this.textBoxSifre.TabIndex = 1;
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(204, 48);
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(366, 39);
            this.textBoxKullaniciAdi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(46, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sifre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanici Adi";
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.groupBoxKullaniciGirisBilgileri);
            this.Controls.Add(this.groupBoxProfilResmi);
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanici Giris";
            this.groupBoxProfilResmi.ResumeLayout(false);
            this.groupBoxProfilResmi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxKullaniciGirisBilgileri.ResumeLayout(false);
            this.groupBoxKullaniciGirisBilgileri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProfilResmi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxKullaniciGirisBilgileri;
        private System.Windows.Forms.Button buttonSistemGiris;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

