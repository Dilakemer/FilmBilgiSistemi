namespace WindowsFormsApp13
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCikis = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGiris = new System.Windows.Forms.Button();
            this.yonetici_radiobutton = new System.Windows.Forms.RadioButton();
            this.premium_radiobutton = new System.Windows.Forms.RadioButton();
            this.standart_radiobutton = new System.Windows.Forms.RadioButton();
            this.sifre_textbox = new System.Windows.Forms.TextBox();
            this.kullaniciadi_textbox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.kayitol_button = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCikis
            // 
            this.buttonCikis.BackColor = System.Drawing.Color.White;
            this.buttonCikis.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.buttonCikis.FlatAppearance.BorderSize = 0;
            this.buttonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCikis.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCikis.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonCikis.Location = new System.Drawing.Point(623, 509);
            this.buttonCikis.Name = "buttonCikis";
            this.buttonCikis.Size = new System.Drawing.Size(118, 50);
            this.buttonCikis.TabIndex = 29;
            this.buttonCikis.Text = "EXIT";
            this.buttonCikis.UseVisualStyleBackColor = false;
            this.buttonCikis.Click += new System.EventHandler(this.buttonCikis_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateBlue;
            this.panel2.Location = new System.Drawing.Point(533, 383);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 1);
            this.panel2.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Location = new System.Drawing.Point(533, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 1);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(631, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 28);
            this.label1.TabIndex = 24;
            this.label1.Text = "LOG IN";
            // 
            // buttonGiris
            // 
            this.buttonGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonGiris.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.buttonGiris.FlatAppearance.BorderSize = 0;
            this.buttonGiris.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGiris.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGiris.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonGiris.Location = new System.Drawing.Point(573, 444);
            this.buttonGiris.Name = "buttonGiris";
            this.buttonGiris.Size = new System.Drawing.Size(203, 50);
            this.buttonGiris.TabIndex = 22;
            this.buttonGiris.Text = "LOG IN";
            this.buttonGiris.UseVisualStyleBackColor = false;
            this.buttonGiris.Click += new System.EventHandler(this.buttonGiris_Click);
            // 
            // yonetici_radiobutton
            // 
            this.yonetici_radiobutton.AutoSize = true;
            this.yonetici_radiobutton.Font = new System.Drawing.Font("Goudy Old Style", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yonetici_radiobutton.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.yonetici_radiobutton.Location = new System.Drawing.Point(514, 218);
            this.yonetici_radiobutton.Name = "yonetici_radiobutton";
            this.yonetici_radiobutton.Size = new System.Drawing.Size(96, 27);
            this.yonetici_radiobutton.TabIndex = 21;
            this.yonetici_radiobutton.TabStop = true;
            this.yonetici_radiobutton.Text = "Yönetici";
            this.yonetici_radiobutton.UseVisualStyleBackColor = true;
            // 
            // premium_radiobutton
            // 
            this.premium_radiobutton.AutoSize = true;
            this.premium_radiobutton.Font = new System.Drawing.Font("Goudy Old Style", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.premium_radiobutton.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.premium_radiobutton.Location = new System.Drawing.Point(748, 218);
            this.premium_radiobutton.Name = "premium_radiobutton";
            this.premium_radiobutton.Size = new System.Drawing.Size(105, 27);
            this.premium_radiobutton.TabIndex = 20;
            this.premium_radiobutton.TabStop = true;
            this.premium_radiobutton.Text = "Premium";
            this.premium_radiobutton.UseVisualStyleBackColor = true;
            // 
            // standart_radiobutton
            // 
            this.standart_radiobutton.AutoSize = true;
            this.standart_radiobutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(38)))));
            this.standart_radiobutton.Font = new System.Drawing.Font("Goudy Old Style", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.standart_radiobutton.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.standart_radiobutton.Location = new System.Drawing.Point(636, 218);
            this.standart_radiobutton.Name = "standart_radiobutton";
            this.standart_radiobutton.Size = new System.Drawing.Size(96, 27);
            this.standart_radiobutton.TabIndex = 19;
            this.standart_radiobutton.TabStop = true;
            this.standart_radiobutton.Text = "Standart";
            this.standart_radiobutton.UseVisualStyleBackColor = false;
            // 
            // sifre_textbox
            // 
            this.sifre_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sifre_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sifre_textbox.Font = new System.Drawing.Font("Goudy Old Style", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sifre_textbox.Location = new System.Drawing.Point(573, 345);
            this.sifre_textbox.Multiline = true;
            this.sifre_textbox.Name = "sifre_textbox";
            this.sifre_textbox.PasswordChar = '*';
            this.sifre_textbox.Size = new System.Drawing.Size(232, 27);
            this.sifre_textbox.TabIndex = 18;
            // 
            // kullaniciadi_textbox
            // 
            this.kullaniciadi_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kullaniciadi_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kullaniciadi_textbox.Font = new System.Drawing.Font("Goudy Old Style", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kullaniciadi_textbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.kullaniciadi_textbox.Location = new System.Drawing.Point(573, 278);
            this.kullaniciadi_textbox.Multiline = true;
            this.kullaniciadi_textbox.Name = "kullaniciadi_textbox";
            this.kullaniciadi_textbox.Size = new System.Drawing.Size(232, 27);
            this.kullaniciadi_textbox.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 586);
            this.panel3.TabIndex = 30;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Black;
            this.label.Font = new System.Drawing.Font("Stencil", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label.Location = new System.Drawing.Point(132, 262);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(216, 51);
            this.label.TabIndex = 2;
            this.label.Text = "Welcome";
            // 
            // kayitol_button
            // 
            this.kayitol_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(38)))));
            this.kayitol_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.kayitol_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.kayitol_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kayitol_button.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kayitol_button.ForeColor = System.Drawing.Color.SteelBlue;
            this.kayitol_button.Location = new System.Drawing.Point(706, 390);
            this.kayitol_button.Name = "kayitol_button";
            this.kayitol_button.Size = new System.Drawing.Size(107, 39);
            this.kayitol_button.TabIndex = 31;
            this.kayitol_button.Text = "Kayıt Ol";
            this.kayitol_button.UseVisualStyleBackColor = false;
            this.kayitol_button.Click += new System.EventHandler(this.kayitol_button_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Silver;
            this.pictureBox5.Image = global::WindowsFormsApp13.Properties.Resources.video_154980_12803;
            this.pictureBox5.Location = new System.Drawing.Point(0, 222);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(441, 132);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = global::WindowsFormsApp13.Properties.Resources.Screenshot_20210427_1131122;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(441, 586);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApp13.Properties.Resources._8703726_lock_security_password_locked_protection_icon;
            this.pictureBox3.Location = new System.Drawing.Point(533, 345);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp13.Properties.Resources._4696641_avatar_people_person_profile_user_icon;
            this.pictureBox2.Location = new System.Drawing.Point(533, 278);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(38)))));
            this.pictureBox1.Image = global::WindowsFormsApp13.Properties.Resources.giris;
            this.pictureBox1.Location = new System.Drawing.Point(612, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(900, 586);
            this.Controls.Add(this.kayitol_button);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonCikis);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonGiris);
            this.Controls.Add(this.yonetici_radiobutton);
            this.Controls.Add(this.premium_radiobutton);
            this.Controls.Add(this.standart_radiobutton);
            this.Controls.Add(this.sifre_textbox);
            this.Controls.Add(this.kullaniciadi_textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCikis;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGiris;
        private System.Windows.Forms.RadioButton yonetici_radiobutton;
        private System.Windows.Forms.RadioButton premium_radiobutton;
        private System.Windows.Forms.RadioButton standart_radiobutton;
        private System.Windows.Forms.TextBox sifre_textbox;
        private System.Windows.Forms.TextBox kullaniciadi_textbox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button kayitol_button;
    }
}

