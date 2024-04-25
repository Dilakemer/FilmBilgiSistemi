using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class YoneticiForm : Form
    {
        public YoneticiForm()
        {
            InitializeComponent();

            VerileriGoster();
            yorum_goruntule();
            panel6.Hide();
            button16.Show();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=Film_Kutuphanesi;user ID=postgres;password=12345");

        private void VerileriGoster()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open(); // bağlantıyı aç
                }

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"Filmler\"", baglanti);

                NpgsqlDataReader dataReader = cmd.ExecuteReader();

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

        private Image FromStream(MemoryStream ms)
        {
            throw new NotImplementedException();
        }

        private void buttonResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtResim.Text = openFileDialog1.FileName;
        }

        private void Ekle_Button_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open(); // bağlantıyı aç
            }

            try
            {
                byte[] resimByte;

                if (!string.IsNullOrEmpty(txtResim.Text) && System.IO.File.Exists(txtResim.Text))
                {
                    resimByte = System.IO.File.ReadAllBytes(txtResim.Text);
                }
                else
                {
                    resimByte = new byte[0];
                }

                NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO \"Filmler\" (\"ID\",\"Ad\",\"Oyuncular\",\"Yönetmen\",\"Tür\",\"Yayın Yılı\",\"Puan\", \"Film Posteri\")" +
                    " VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) RETURNING \"ID\"", baglanti);

                komut1.Parameters.AddWithValue("@p1", BigInteger.Parse(txtID.Text));
                komut1.Parameters.AddWithValue("@p2", txtAd.Text);
                komut1.Parameters.AddWithValue("@p3", txtYonetmen.Text);
                komut1.Parameters.AddWithValue("@p4", txtOyuncular.Text);
                komut1.Parameters.AddWithValue("@p5", txtTur.Text);
                komut1.Parameters.AddWithValue("@p6", DateTime.Parse(txtYil.Text));
                komut1.Parameters.AddWithValue("@p7", Double.Parse(txtPuan.Text));
                komut1.Parameters.AddWithValue("@p8", resimByte);

                komut1.ExecuteNonQuery();
                MessageBox.Show("Film ekleme işlemi başarılı");
                VerileriGoster();
            }
            finally
            {
                if(baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close(); //bağlantıyı kapat
                }
            }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open(); // bağlantıyı aç
            }

            if (BigInteger.TryParse(txtID.Text, out BigInteger id))
            {
                // sql sorgusunu oluştur ve sadece dolu olan TextBox'ları güncelle
                NpgsqlCommand komut2 = new NpgsqlCommand("UPDATE \"Filmler\" SET " +
                                                        "\"Ad\"=@p2, " +
                                                        "\"Oyuncular\"=@p3, " +
                                                        "\"Yönetmen\"=@p4, " +
                                                        "\"Tür\"=@p5,  " +
                                                        "\"Yayın Yılı\"=@p6, " +
                                                        "\"Puan\"=@p7, " +
                                                        "\"Film Posteri\"=@p8 " +
                                                        "WHERE \"ID\"=@p1", baglanti);

                komut2.Parameters.AddWithValue("@p1", id);
                komut2.Parameters.AddWithValue("@p2", NpgsqlDbType.Text, txtAd.Text);
                komut2.Parameters.AddWithValue("@p3", NpgsqlDbType.Text,  txtYonetmen.Text);
                komut2.Parameters.AddWithValue("@p4", NpgsqlDbType.Text, txtOyuncular.Text);
                komut2.Parameters.AddWithValue("@p5", NpgsqlDbType.Text, txtTur.Text);
                komut2.Parameters.AddWithValue("@p6", NpgsqlDbType.Date, DateTime.Parse(txtYil.Text));
                komut2.Parameters.AddWithValue("@p7", NpgsqlDbType.Double, Double.Parse(txtPuan.Text));

                byte[] resimByte;
                if (!string.IsNullOrEmpty(txtResim.Text) && File.Exists(txtResim.Text))
                {
                    resimByte = File.ReadAllBytes(txtResim.Text);
                    komut2.Parameters.AddWithValue("@p8", NpgsqlDbType.Bytea, resimByte);
                }
                else
                {
                    komut2.Parameters.AddWithValue("@p8", NpgsqlDbType.Bytea, DBNull.Value);
                }

                komut2.ExecuteNonQuery();

                MessageBox.Show("Film güncelleme işlemi başarılı");
                VerileriGoster();
            }
            else
            {
                MessageBox.Show("Geçersiz id formatı");
            }

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close(); //bağlantıyı kapat
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtYonetmen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtOyuncular.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTur.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtYil.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtPuan.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open(); // bağlantıyı aç
            }

            int filmID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (NpgsqlCommand komut5 = new NpgsqlCommand("SELECT * FROM \"Filmler\" WHERE \"ID\" = @filmID", baglanti))
            {
                komut5.Parameters.AddWithValue("@filmID", filmID);

                using (NpgsqlDataReader dr = komut5.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int filmPosterIndex = dr.GetOrdinal("Film Posteri");

                        if (!dr.IsDBNull(filmPosterIndex))
                        {
                            byte[] resim = (byte[])dr[filmPosterIndex];
                            MemoryStream ms = new MemoryStream(resim);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
            }
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close(); //bağlantıyı kapat
            }
        }

        private void Sil_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open(); // bağlantıyı aç
                }

                int filmID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                using (NpgsqlCommand silKomut = new NpgsqlCommand("DELETE FROM \"Filmler\" WHERE \"ID\" = @filmID", baglanti))
                {
                    silKomut.Parameters.AddWithValue("@filmID", filmID);
                    silKomut.ExecuteNonQuery();
                }

                MessageBox.Show("Film silme işlemi başarılı");
                VerileriGoster();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close(); // bağlantıyı kapat
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir film seçin.");
            }
        }

        private void yorum_goruntule()
        {
            string sorgu = "select * from yorumlar ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewyorum.DataSource = ds.Tables[0];
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtAd.Clear();
            txtYonetmen.Clear();
            txtOyuncular.Clear();
            txtTur.Clear();
            txtYil.Clear();
            txtPuan.Clear();
            txtResim.Clear();
            pictureBox1.Image = null;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex=0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            button16.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.Hide();
            panel6.Show();
        }

        private void buttonIstatistik_Click(object sender, EventArgs e)
        {
            Istatistik ıstatistik = new Istatistik();
            ıstatistik.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
