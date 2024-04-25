using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    public abstract class Film
    {
        public string Ad { get; set; }
        public string Yonetmen { get; set; }
        public string Oyuncular { get; set; }
        public DateTime Yayin_yili { get; set; }
        public double Puan { get; set; }
        public tur Tur { get; set; }
        public enum tur
        {
            Fantastik,BilimKurgu,Animasyon,Korku,Gerilim,Dram,Komedi
        }
        public Film(string ad, string yonetmen, string oyuncular, DateTime yayinYili, double puan, tur tur)
        {
            Ad = ad;
            Yonetmen = yonetmen;
            Oyuncular = oyuncular;
            Yayin_yili = yayinYili;
            Puan = puan;
            Tur = tur;
        }

    }
}
