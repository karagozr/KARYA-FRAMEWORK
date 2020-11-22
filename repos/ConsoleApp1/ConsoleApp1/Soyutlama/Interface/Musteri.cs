using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Soyutlama.Interface
{
    public class Musteri :IKisi
    {
        public string Email;

        public double Bakiye;

        public string Ad    { get; set; }
        public string Soyad { get; set; }
    }
}
