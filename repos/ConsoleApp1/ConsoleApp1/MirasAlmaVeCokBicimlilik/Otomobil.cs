using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MirasAlma
{
    public class Otomobil
    {
        public int TekerSayisi = 4;

        public double YakitKapasitesi=1;

        public double Menzil = 1;

        protected virtual double YakitTuketimiHesapla()
        {
            return 100 * YakitKapasitesi / Menzil;
        }
    }
}
