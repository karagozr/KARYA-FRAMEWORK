using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Urun
    {
        public int Id { get; set; }

        public string UrunAd { get; set; }

        public double Miktar { get; set; }

        public double Fiyat { get; set; }
    }
}