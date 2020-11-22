using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MirasAlma
{
    public class BugattiVeyron : Otomobil
    {
        public string KAtegori = "Süper Spor";

        public double BugattiYakitKapasiytesi = 180;

        public double BugattiMenzili = 500;

        public bool SuperTurboAcildiMi = true;

        protected override double YakitTuketimiHesapla()
        {
            return SuperTurboAcildiMi ? (100 * BugattiYakitKapasiytesi / BugattiMenzili) * 2.2 : (100 * BugattiYakitKapasiytesi / BugattiMenzili);
        }
    }
}
