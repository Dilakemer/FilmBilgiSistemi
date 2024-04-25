using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=Film_Kutuphanesi;user ID=postgres;password=12345");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            string kullanici_adi = kullaniciadi_textbox.Text;
            string sifre = sifre_textbox.Text;

            if (yonetici_radiobutton.Checked)
            {
                if (kullanici_adi == "admin" && sifre == "12345")
                {
                    baglanti.Close();
                    YoneticiForm yonetici = new YoneticiForm();
                    yonetici.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
                }
            }
            else if (standart_radiobutton.Checked)
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open(); // bağlantıyı aç
                }

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"kullanicilar\" where kullanici_adi='" + kullanici_adi + "'And sifre='" + sifre + "'And \"Üyelik Türü\" = 'Standart'", baglanti);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    baglanti.Close();
                    KullaniciForm Kullanici = new KullaniciForm(kullanici_adi);
                    Kullanici.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı, Şifre veya Kullanıcı Tipi");
                    kullaniciadi_textbox.Clear();
                    sifre_textbox.Clear();
                    kullaniciadi_textbox.Focus();
                }
            }
            else if (premium_radiobutton.Checked)
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open(); // bağlantıyı aç
                }

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"kullanicilar\" where kullanici_adi='" + kullanici_adi + "'And sifre='" + sifre + "'And \"Üyelik Türü\" = 'Premium'", baglanti);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    baglanti.Close();
                    KullaniciForm Kullanici = new KullaniciForm(kullanici_adi);
                    Kullanici.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı, Şifre veya Kullanıcı Tipi");
                    kullaniciadi_textbox.Clear();
                    sifre_textbox.Clear();
                    kullaniciadi_textbox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Tipi Seçiniz !");
            }
        }

        private void buttonCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kayitol_button_Click(object sender, EventArgs e)
        {

            kayıtol Kayıtol = new kayıtol();
            Kayıtol.Show();
            
        }
    }
}
