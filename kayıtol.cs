using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class kayıtol : Form
    {
        public kayıtol()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=Film_Kutuphanesi;user ID=postgres;password=12345");

        private void buttonKayıt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO kullanicilar (\"Ad-Soyad\", \"TC\", \"Doğum Tarihi\", \"Cinsiyet\", \"Üyelik Türü\", \"kullanici_adi\", \"sifre\") VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglanti);

            komut1.Parameters.AddWithValue("@p1", adsoyad.Text);
            komut1.Parameters.AddWithValue("@p2", BigInteger.Parse(tc.Text));
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse(dogumtarihi.Text));
            komut1.Parameters.AddWithValue("@p4", cinsiyet.Text);
            komut1.Parameters.AddWithValue("@p5", uyelikturu.Text);
            komut1.Parameters.AddWithValue("@p6", kullanıcıadi.Text);
            komut1.Parameters.AddWithValue("@p7", sifre.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kullanıcı ekleme işlemi başarılı");
        }

        private void buttonGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
