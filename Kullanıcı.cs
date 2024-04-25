using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    public abstract class Kullanıcı
    {
        public string AdSoyad { get; set; }
        public double Tc { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public uyelikturu UyelikTuru { get; set; }
        public enum uyelikturu
        {
            Premium,Standart
        }
        public Kullanıcı(string adSoyad, double tc, DateTime dogumTarihi, string cinsiyet, uyelikturu uyelikTuru)
        {
            AdSoyad = adSoyad;
            Tc = tc;
            DogumTarihi = dogumTarihi;
            Cinsiyet = cinsiyet;
            UyelikTuru = uyelikTuru;
        }
        public abstract double UcretHesapla();

        
    }
}
