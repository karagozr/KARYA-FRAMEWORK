
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class MusteriServis
    {
        public MusteriServis()
        {
        }

        public List<Musteri> MusteriAra(string _musteriAdi)
        {

            using (var connection = new SqlConnection(@"Persist Security Info=True;Data Source=.;Initial Catalog=ETICARET;User ID=sa;Password=1234"))
            {
                var musteriler = connection.Query<Musteri>($"Select * FROM Musteriler WHERE AdSoyad like '%{_musteriAdi}%'").ToList();
                return musteriler;
            }

            
        }

        public void MusterEkle(Musteri _musteri)
        {
            string sql = $"INSERT INTO Musteriler (AdSoyad) Values ('{_musteri.AdSoyad}');";

            using (var connection = new SqlConnection(@"Persist Security Info=True;Data Source=.;Initial Catalog=ETICARET;User ID=sa;Password=1234"))
            {
                var result = connection.Execute(sql);

            }
        }

    }
}