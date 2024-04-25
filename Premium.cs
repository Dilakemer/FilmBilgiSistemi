using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    internal class Premium:Kullanıcı
    {
        public Premium(string adSoyad, double tc, DateTime dogumTarihi, string cinsiyet) :base(adSoyad,tc,dogumTarihi,cinsiyet,uyelikturu.Premium)
        {
            UyelikTuru = uyelikturu.Premium;
        }

        public override double UcretHesapla()
        {
            double indirimsizFiyat = 100.0;
            double artis = 0.25;
            double fiyat = indirimsizFiyat + (indirimsizFiyat * artis);
            return fiyat;
        }
    }
}
