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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp13
{
    public partial class KullaniciForm : Form
    {
        private string kullaniciAdi;
        private Standart standart;
        private Premium premium;

        public KullaniciForm(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // ikinci datagridview'e "Çıkar" buton sütunu ekle
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.Name = "Cikar";
            removeButtonColumn.HeaderText = "Çıkar";
            removeButtonColumn.Text = "Çıkar";
            removeButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(removeButtonColumn);
        }

        //veritabanı bağlantısı
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=Film_Kutuphanesi;user ID=postgres;password=12345");

        private void VeriGoster()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open(); // bağlantıyı aç
                }

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"Filmler\"", baglanti); // tüm filmleri filtreleyen sql sorgusu

                NpgsqlDataReader dataReader = cmd.ExecuteReader(); // komutu çalıştır ve verileri oku

                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataGridView1.DataSource = dataTable;

                dataReader.Close();
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close(); //bağlantıyı kapat
                }
            }
        }

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            VeriGoster();
            label1.Text = "Arama Yap ";
            //datagridview1'e "Ekle" buton sütunu ekle
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Ekle";
            buttonColumn.HeaderText = "Ekle";
            buttonColumn.Text = "Ekle";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                // kullanıcı adına göre kullanıcı bilgilerini getiren sql sorgusu
                NpgsqlCommand komut4 = new NpgsqlCommand("SELECT * FROM \"kullanicilar\" WHERE \"kullanici_adi\" = @kullanici", baglanti);
                komut4.Parameters.AddWithValue("@kullanici", kullaniciAdi);

                NpgsqlDataReader dataReader = komut4.ExecuteReader();

                if (dataReader.Read())
                {
                    //kullanıcının bilgilerini veritabanından oku ve ilgili textboxlara yazdır
                    textBoxAd.Text = dataReader["Ad-Soyad"].ToString();
                    textBoxTC.Text = dataReader["TC"].ToString();
                    textBoxDt.Text = dataReader["Doğum Tarihi"].ToString();
                    textBoxCinsiyet.Text = dataReader["Cinsiyet"].ToString();

                    // üyelik türüne göre ilgili radio butonu işaretleme ve classlardan nesne oluştur
                    string uyelik = dataReader["Üyelik Türü"].ToString();
                    if (uyelik == "Standart")
                    {
                        radioButtonStandart.Checked = true;
                        standart = new Standart(textBoxAd.Text, Convert.ToDouble(textBoxTC.Text), Convert.ToDateTime(textBoxDt.Text), textBoxCinsiyet.Text);

                    }
                    else if (uyelik == "Premium")
                    {
                        radioButtonPremium.Checked = true;
                        premium = new Premium(textBoxAd.Text, Convert.ToDouble(textBoxTC.Text), Convert.ToDateTime(textBoxDt.Text), textBoxCinsiyet.Text);

                    }
                }
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close(); //bağlantıyı kapat
                }
            }

            if (premium != null)
            {
                // eğer premium kullanıcı giriş yapmışsa puanlama araçlarını göster
                labelPuan.Visible = true;
                puanTextbox.Visible = true;
                puanbutton.Visible = true;
            }
            else if(standart != null)
            {
                //eğer standart kullanıcı giriş yapmışsa puanlama araçlarını sakla
                labelPuan.Visible = false;
                puanTextbox.Visible = false;
                puanbutton.Visible = false;
            }

            notifyIcon1.BalloonTipText = "Kullanıcı Girişi Başarılı";
            notifyIcon1.BalloonTipTitle = "Film Kütüphanesine Hoşgeldiniz!";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.ShowBalloonTip(3000);

            UcretHesaplaVeYazdir();
        }

        private void UcretHesaplaVeYazdir()
        {
            // oluşturulan nesneler ile gerekli metodun çağırılması ve ilgili textboxa yazdırma işlemi
            if (standart != null)
            {
                double ucret = standart.UcretHesapla();
                textBoxUcret.Text = ucret.ToString("C"); //"C" TL olarak yazdırmak için kullan
            }
            else if (premium != null)
            {
                double ucret = premium.UcretHesapla();
                textBoxUcret.Text = ucret.ToString("C"); //"C" TL olarak yazdırmak için kullan
            }
            else
            {
                textBoxUcret.Text = "Belirlenmedi";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProperty = comboBox1.SelectedItem.ToString(); //comboboxta seçilen itemı selectedProperty'e ata

            switch (selectedProperty)
            {
                case "":
                    label1.Text = "Tüm Filmler ";

                    break;

                case "Ad":
                    label1.Text = "Film Adı: ";
                    break;

                case "Yönetmen":
                    label1.Text = "Yönetmen: ";
                    break;

                case "Tür":
                    label1.Text = "Tür: ";

                    break;
                case "Yayın Yılı":
                    label1.Text = "Yıl: ";

                    break;
                case "Puan":
                    label1.Text = "Puan: ";
                    break;

                default:
                    break;
            }
        }


        private void FilmArabutton_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open(); // bağlantıyı aç
            }

            if (!string.IsNullOrEmpty(filmadi_textbox.Text))
            {
                string selectedProperty = comboBox1.SelectedItem.ToString();
                string sorgu = "";

                if (selectedProperty == "Yayın Yılı")
                {
                    // sadece girilen yıl değerine eşit tarihli filmlerin sql sorgusu
                    sorgu = $"SELECT * FROM \"Filmler\" WHERE EXTRACT(YEAR FROM \"Yayın Yılı\") = @param :: integer";
                }
                else
                {
                    if (selectedProperty == "Puan")
                    {

                        if (double.TryParse(filmadi_textbox.Text, out double puan))
                        {
                            sorgu = $"SELECT * FROM \"Filmler\" WHERE CAST(\"{selectedProperty}\" AS TEXT) ILIKE @param";
                        }
                        else
                        {
                            MessageBox.Show("Geçersiz Puan Formatı");
                            return;
                        }
                    }
                    else
                    {

                        sorgu = $"SELECT * FROM \"Filmler\" WHERE CAST(\"{selectedProperty}\" AS TEXT) ILIKE @param";
                    }
                }

                NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglanti);

                if (selectedProperty == "Puan")
                {
                    cmd.Parameters.AddWithValue("@param", "%" + filmadi_textbox.Text + "%");
                }
                else if (selectedProperty == "Yayın Yılı")
                {
                    int yil;
                    if (int.TryParse(filmadi_textbox.Text, out yil))
                    {
                        cmd.Parameters.AddWithValue("@param", yil);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz Yıl Formatı");
                        return;
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@param", "%" + filmadi_textbox.Text + "%");
                }

                NpgsqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedItem.ToString() == "")
            {
                //eğer comboboxtaki item değeri "" ise tüm filmleri göster
                VeriGoster();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer "Ekle" butonuna tıklanmışsa ve seçilen bir satır varsa
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ekle" && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                ShowNotification("Film Eklendi", "Seçilen film başarıyla eklendi.");

                // Yeni bir satır oluştur
                DataGridViewRow newRow = new DataGridViewRow();

                // Hücreleri tek tek kopyala
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name != "Ekle") // Ekle butonunu kopyalamayın
                    {
                        // Yeni bir hücre oluştur ve değeri kopyala
                        DataGridViewCell newCell = new DataGridViewTextBoxCell();
                        newCell.Value = cell.Value;

                        // Yeni hücreyi yeni satıra ekle
                        newRow.Cells.Add(newCell);
                    }
                }
                // Yeni satırı dataGridView2'ye ekle
                dataGridView2.Rows.Add(newRow);
            }
        }


        private void ShowNotification(string title, string text)
        {
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Cikar" && e.RowIndex >= 0)
            {
                // Seçilen satırı dataGridView2'den kaldır
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }


        private void hesap_kapat_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                // Kullanıcıyı tablodan sil
                NpgsqlCommand cmdSil = new NpgsqlCommand("DELETE FROM \"kullanicilar\" WHERE \"kullanici_adi\" = @kullanici", baglanti);
                cmdSil.Parameters.AddWithValue("@kullanici", kullaniciAdi);

                int silinenSatir = cmdSil.ExecuteNonQuery();

                if (silinenSatir > 0)
                {
                    MessageBox.Show("Hesabınız Silinmiştir");
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Close();  // Formu kapat
                }
                else
                {
                    MessageBox.Show("Hesap kapatma işlemi başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        private DataTable GetYorumlar(int filmID)
        {
            DataTable yorumlar = new DataTable();

            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"yorumlar\" WHERE filmid = @filmID", baglanti))
            {
                cmd.Parameters.AddWithValue("@filmID", filmID);

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(yorumlar);
                }
            }
            return yorumlar;
        }


        private void GosterYorumlar(int filmID)
        {
            //verilen film id'sine ait yorumları getiren metod
            DataTable yorumlar = GetYorumlar(filmID);

            //DataGridView'de yorumları gösterme
            dataGridViewYorumlar.DataSource = yorumlar;
        }

        private void buttonIstatistik_Click(object sender, EventArgs e)
        {
            Istatistik ıstatistik = new Istatistik();
            ıstatistik.Show();
        }

        private void buttonYorumYap_Click(object sender, EventArgs e)
        {
            //DataGridView1'de seçilen sütun var mı kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // ilk seçili satırın film id'sini al
                int selectedFilmID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // kullanıcının textboxa yazdığı yorumu al
                string yorum = textBoxYorum.Text;

                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                //yorum eklemek için sql sorgusu
                NpgsqlCommand cmdYorumEkle = new NpgsqlCommand("INSERT INTO \"yorumlar\" (filmid, kullaniciadi, yorum ) VALUES (@filmID, @kullaniciAdi, @yorum)", baglanti);
                cmdYorumEkle.Parameters.AddWithValue("@filmID", selectedFilmID);
                cmdYorumEkle.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                cmdYorumEkle.Parameters.AddWithValue("@yorum", yorum);

                int affectedRows = cmdYorumEkle.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Yorum başarıyla eklendi.");
                    string sorgu = "select * from yorumlar ";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridViewYorumlar.DataSource = ds.Tables[0];

                }
                else
                {
                    MessageBox.Show("Yorum eklenirken bir hata oluştu.");
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Lütfen yorum yapmak istediğiniz bir film seçin.");
            }
        }

        private void puanbutton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(puanTextbox.Text, out double yeniPuan))
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedFilmID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                    if (baglanti.State != ConnectionState.Open)
                    {
                        baglanti.Open();
                    }

                    try
                    {
                        // Seçili film için mevcut puanları getir
                        string sorguPuanlar = $"SELECT \"Puan\" FROM \"Filmler\" WHERE \"ID\" = @filmID";
                        NpgsqlCommand cmdPuanlar = new NpgsqlCommand(sorguPuanlar, baglanti);
                        cmdPuanlar.Parameters.AddWithValue("@filmID", selectedFilmID);

                        NpgsqlDataReader readerPuanlar = cmdPuanlar.ExecuteReader();

                        List<double> puanlar = new List<double>();
                        while (readerPuanlar.Read())
                        {
                            if (double.TryParse(readerPuanlar["Puan"].ToString(), out double puan))
                            {
                                puanlar.Add(puan);
                            }
                        }

                        readerPuanlar.Close();

                        // Yeni puanı ekle
                        puanlar.Add(yeniPuan);

                        // Puanları kullanarak ortalama puanı hesapla
                        double ortalamaPuan = puanlar.Count > 0 ? puanlar.Average() : 0;

                        // Ortalama puanı "Filmler" tablosuna güncelle
                        string sorguGuncellePuan = "UPDATE \"Filmler\" SET \"Puan\" = @ortalamaPuan WHERE \"ID\" = @filmID";
                        NpgsqlCommand cmdGuncellePuan = new NpgsqlCommand(sorguGuncellePuan, baglanti);
                        cmdGuncellePuan.Parameters.AddWithValue("@ortalamaPuan", ortalamaPuan);
                        cmdGuncellePuan.Parameters.AddWithValue("@filmID", selectedFilmID);

                        int affectedRows = cmdGuncellePuan.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Puan başarıyla güncellendi.");
                            dataGridView1.DataSource = null;
                            VeriGoster();
                        }
                        else
                        {
                            MessageBox.Show("Puan güncelleme işlemi başarısız oldu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                    finally
                    {
                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen puan eklemek istediğiniz bir film seçin.");
                }
            }
            else
            {
                MessageBox.Show("Geçersiz puan formatı.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}

