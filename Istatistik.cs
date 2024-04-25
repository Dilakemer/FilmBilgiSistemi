using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Istatistik : Form
    {
        public Istatistik()
        {
            InitializeComponent();
            VerileriGoster();
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

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"Tür\", AVG(\"Puan\") AS \"Ortalama Puan\" FROM \"Filmler\" GROUP BY \"Tür\"", baglanti);

                NpgsqlDataReader dataReader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);

                // Chart kontrolüne verileri ekle
                chart1.Series.Clear();
                chart1.Series.Add("Ortalama Puan");
                chart1.Series["Ortalama Puan"].Points.DataBindXY(dataTable.AsEnumerable().Select(r => r.Field<string>("Tür")).ToArray(), dataTable.AsEnumerable().Select(r => r.Field<double>("Ortalama Puan")).ToArray());
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close(); //bağlantıyı kapat
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
