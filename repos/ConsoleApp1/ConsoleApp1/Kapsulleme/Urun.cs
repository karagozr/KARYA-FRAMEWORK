using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Kapsulleme
{

    /*
     Kapsülleme yaparak ile metod veya fieldlarımızın erişim kısıtını belirleyebiliriz.
     Private sadece kendi sınısında erişilir. Public dışarıdan erişilirç
     */
    public class Urun
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public double Fiyat { get; set; }

        private void FiyatiZamla()
        {
            Fiyat = Fiyat * 1.12;
        }
    }
}
