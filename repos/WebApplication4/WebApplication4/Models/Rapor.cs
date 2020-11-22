using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Rapor
    {
        public int MusteriId { get; set; }
        public string MusteriAdSoyad { get; set; }
        public double ToplamSiparis { get; set; }
        public double EnPahaliUrun { get; set; }
    }
}