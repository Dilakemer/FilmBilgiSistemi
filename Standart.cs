using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    internal class Standart:Kullanıcı
    {
        public Standart(string adSoyad, double tc, DateTime dogumTarihi, string cinsiyet) : base(adSoyad, tc, dogumTarihi, cinsiyet, uyelikturu.Standart)
        {
            UyelikTuru = uyelikturu.Standart;
        }

        public override double UcretHesapla()
        {
            double indirimsizFiyat = 100.0;
            return indirimsizFiyat;
        }
    }
}
