using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication4.Models
{
    public class SiparisServis
    {
        Siparis _siparis;

        public SiparisServis()
        {
            _siparis = new Siparis();
        }

        public List<Siparis> SiparisListesi()
        {
            var siparisler = new List<Siparis>();

            siparisler.Add(
                new Siparis
                {
                    Id = 1,
                    Musteri = new Musteri
                    {
                        Id = 1,
                        AdSoyad = "Ali"
                    },
                    Urunler = new List<Urun>
                    {
                        new Urun
                        {
                            Id=1,
                            Fiyat=25,
                            Miktar=2,
                            UrunAd="Urun1"
                        },

                        new Urun
                        {
                            Id=2,
                            Fiyat=2.5,
                            Miktar=10,
                            UrunAd="Urun2"
                        }
                    }
                });

            siparisler.Add(
                new Siparis
                {
                    Id = 2,
                    Musteri = new Musteri
                    {
                        Id = 1,
                        AdSoyad = "Ali"
                    },
                    Urunler = new List<Urun>
                    {
                        new Urun
                        {
                            Id=5,
                            Fiyat=100,
                            Miktar=7,
                            UrunAd="Urun5"
                        },

                        new Urun
                        {
                            Id=4,
                            Fiyat=2,
                            Miktar=20,
                            UrunAd="Urun4"
                        }
                    }
                });

            siparisler.Add(
               new Siparis
               {
                   Id = 3,
                   Musteri = new Musteri
                   {
                       Id = 2,
                       AdSoyad = "Ayşe"
                   },
                   Urunler = new List<Urun>
                   {
                        new Urun
                        {
                            Id=11,
                            Fiyat=20,
                            Miktar=2,
                            UrunAd="Urun11"
                        },

                        new Urun
                        {
                            Id=20,
                            Fiyat=82.5,
                            Miktar=10,
                            UrunAd="Urun20"
                        }
                   }
               });

            siparisler.Add(
                new Siparis
                {
                    Id = 4,
                    Musteri = new Musteri
                    {
                        Id = 2,
                        AdSoyad = "Ayşe"
                    },
                    Urunler = new List<Urun>
                    {
                        new Urun
                        {
                            Id=6,
                            Fiyat=10,
                            Miktar=70,
                            UrunAd="Urun6"
                        },

                        new Urun
                        {
                            Id=4,
                            Fiyat=2,
                            Miktar=200,
                            UrunAd="Urun4"
                        }
                    }
                });

            siparisler.Add(
              new Siparis
              {
                  Id = 5,
                  Musteri = new Musteri
                  {
                      Id = 3,
                      AdSoyad = "Elif"
                  },
                  Urunler = new List<Urun>
                  {
                        new Urun
                        {
                            Id=11,
                            Fiyat=20,
                            Miktar=2,
                            UrunAd="Urun11"
                        },

                        new Urun
                        {
                            Id=20,
                            Fiyat=82.5,
                            Miktar=10,
                            UrunAd="Urun20"
                        }
                  }
              });

            siparisler.Add(
                new Siparis
                {
                    Id = 6,
                    Musteri = new Musteri
                    {
                        Id = 3,
                        AdSoyad = "Elif"
                    },
                    Urunler = new List<Urun>
                    {
                        new Urun
                        {
                            Id=54,
                            Fiyat=18,
                            Miktar=3,
                            UrunAd="Urun54"
                        },

                        new Urun
                        {
                            Id=4,
                            Fiyat=2,
                            Miktar=200,
                            UrunAd="Urun4"
                        }
                    }
                });


            return siparisler;
        }

        public List<Rapor> SiparisOzet()
        {
            var siparisler = SiparisListesi();

            return siparisler.GroupBy(sip => new { sip.Musteri.Id, sip.Musteri.AdSoyad })
                        .Select(group => new Rapor
                        {
                            MusteriId = group.Key.Id,
                            MusteriAdSoyad = group.Key.AdSoyad,
                            ToplamSiparis = group.Sum(s => s.Urunler.Sum(x => x.Fiyat * x.Miktar)),
                            EnPahaliUrun = group.Max(s => s.Urunler.Select(x => new { x.UrunAd, x.Fiyat }).Max(x => x.Fiyat))
                        }).OrderBy(x => x.MusteriId).ToList();
        }

        public List<Rapor> SiparisOzet(string _musteriAdi)
        {
            var siparisler = SiparisListesi();

            return siparisler.Where(x => _musteriAdi.Contains(x.Musteri.AdSoyad)).GroupBy(sip => new { sip.Musteri.Id, sip.Musteri.AdSoyad })
                        .Select(group => new Rapor
                        {
                            MusteriId = group.Key.Id,
                            MusteriAdSoyad = group.Key.AdSoyad,
                            ToplamSiparis = group.Sum(s => s.Urunler.Sum(x => x.Fiyat * x.Miktar)),
                            EnPahaliUrun = group.Max(s => s.Urunler.Select(x => new { x.UrunAd, x.Fiyat }).Max(x => x.Fiyat))
                        }).OrderBy(x => x.MusteriId).ToList();
        }

    }
}