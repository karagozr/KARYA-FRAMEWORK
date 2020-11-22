using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpRequestApp
{
    public class DosyaListe
    {
        /*<tr class="ui-widget-header ">
                <th>No.</th>
                <th>Kesinti Bildirim List. S�ra No.</th>
                <th>D�nem</th>
                <th>Durum</th>
                <th>Olu�turma Tarihi</th>
                <th>Sil</th>
            </tr>*/
        public int No;
        public string SiraNo;
        public string Donem;
        public string Durum;
        public string OlusturmaTarihi;
        public string Sil;

    }

    public partial class Form1 : Form
    {

        int dateTime = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox.Image = BagkurHelper.GetGuvenlikAnahtari();
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            dateTime = (int)t.TotalSeconds;
        }

        private void btnHttpRequest_Click(object sender, EventArgs e)
        {
            pictureBox.Image = BagkurHelper.GetGuvenlikAnahtari();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (var item in BagkurHelper.cookieValues)
            {
                textArea.Text += ($"-------------------------------------------------------------------------------------------------------------------------\n");

                textArea.Text += ($"{item.Name} = {item.Value}\n");
            }
            /*
             * mernisNo: 23213
             * password: 123123
             * guvenlikAnahtari: 7d3ca
             * sifremiUnuttum: false
             */
            var mernisNo = txtKullaniciKodu.Text;
            var password = txtSifre.Text;
            var guvenlikAnahtari = txtGuvenlikKodu.Text;
            var sifremiUnuttum = false;

            byte[] data = Encoding.ASCII.GetBytes($"mernisNo={mernisNo}&password={password}&guvenlikAnahtari={guvenlikAnahtari}&sifremiUnuttum={sifremiUnuttum}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/LoginAction.do");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }



            request.CookieContainer = new CookieContainer();

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                textArea.Text += "**************************************************************************\n";
                List<CookieValue> _cookieValues = new List<CookieValue>();
                foreach (Cookie cook in response.Cookies)
                {
                    //_cookieValues.Add(new CookieValue
                    //{
                    //    Name = cook.Name,
                    //    Value = cook.Value
                    //});

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }

                    //#	Result	Protocol	Host	URL	Body	Caching	Content-Type	Process	Comments	Custom	
                    /// 37  200 HTTPS uyg.sgk.gov.tr / TAKEP / AcikDosyaSayisiniKontrolEtAction.do 32      text / plain; charset = UTF - 8    entegre: 6136
                    //#	Result	Protocol	Host	URL	Body	Caching	Content-Type	Process	Comments	Custom	
                    // 25  200 HTTPS uyg.sgk.gov.tr / TAKEP / TevkifatKesintiIcinUreticiSorgulaAction.do 33      text / plain; charset = UTF - 8    entegre: 6136


                }

                foreach (var item in BagkurHelper.cookieValues)
                {
                    textArea.Text += ($"-------------------------------------------------------------------------------------------------------------------------\n");

                    textArea.Text += ($"{item.Name} = {item.Value}\n");
                }

                textArea.Text += "**************************************************************************\n";
                textArea.Text += "**************************************************************************\n";
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string Json = rdr.ReadToEnd(); // response from server

                    textArea.Text = Json;
                }



            }

            ///pictureBox.Image = BagkurHelper.GetGuvenlikAnahtari();

        }



        private void btnSorgula_Click(object sender, EventArgs e)
        {
            TimeSpan t1 = DateTime.Now - new DateTime(1970, 1, 1);
            //26722118458
            var mernisno = txtTcNo.Text;
            var isAraButtonPressed = 1;
            var alimZamani = "Alim Gerceklesecek";
            var odemeTarihi = dateTimePicker1.Value.ToString(@"dd.MM.yyyy");
            var ds = (long)t1.TotalMilliseconds;
            //1600545002826;
            //1600613444
            //1600624538604

            byte[] data = Encoding.ASCII.GetBytes($"mernisno={mernisno}&" +
                                                  $"isAraButtonPressed={isAraButtonPressed}&" +
                                                  $"alimZamani={alimZamani}&" +
                                                  $"odemeTarihi={odemeTarihi}&ds={ds}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/TevkifatKesintiIcinUreticiSorgulaAction.do");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();


            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            //request.CookieContainer.Add(new Uri("https://uyg.sgk.gov.tr"), new Cookie("TS01a13529", "0198372d58ce93778e3104e3181aaed0884c62dba72f882bb0d32ca82dc9cc0695e5ef10d35260cb6b1125b351828c15558de8a125229ce527fa222f3baebfcd66015a16a8ef1084bca72154824649099721dfb07d5953c31928206e741fec98197311b05b", "/", ".uyg.sgk.gov.tr"));
            //request.CookieContainer.Add(new Uri("https://uyg.sgk.gov.tr"), new Cookie("JSESSIONID", "0000aU0hWCofhdxQG5QZv2034WY:1ehbvla0v", "/", ".uyg.sgk.gov.tr"));
            //request.CookieContainer.Add(new Uri("https://uyg.sgk.gov.tr"), new Cookie("BIGipServerU/J6BNS+9bVSXgKsFC0AhA", "!db4qF3yKEfbeMmDOHv+JoHj3Fnyf3oFnIuT5L4Bi7M+7sGe+W2vyyPX2L5UzMMuTImBiOLSsGat+uw==", "/", ".uyg.sgk.gov.tr"));
            //request.CookieContainer.Add(new Uri("https://uyg.sgk.gov.tr"), new Cookie("BIGipServer63Ttwix0HCqVDZ0YLl0naw", "!j+6wLFVS+b8ffLv9UxWNKo9iLR+0L7rTGAt+eEUMsdo0ZayQwLisT3nttZZbqkIzxCzBQKNIoayrY9g=", "/", ".uyg.sgk.gov.tr"));

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //string content = new StreamReader(response.GetResponseStream()).ReadToEnd();


            using (WebResponse response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string Json = rdr.ReadToEnd(); // response from server

                    textArea.Text = Json;

                }
            }







            //Content - Type: text / plain; charset = UTF - 8
            //Date: Thu, 17 Sep 2020 22:22:11 GMT
            //Set - Cookie: TS01a13529 = 0198372d58c91fa6dbe06ec544b56f2d94e356da09458a3a810439e466fde2d7663a1c4e7fd28a76785471bc068dd77a52c6a86b6b55e5e6a267207a970dc6dccb48702f2a0616b69435dbf311011b4fdc74e4193171edd7419ef1fa324b4b192b73625489; Path =/; Domain =.uyg.sgk.gov.tr; Secure; HTTPOnly
        }



        //pages/jsp/dosya_list.jsp?_= 1600598430863

        //https://uyg.sgk.gov.tr/TAKEP/SecilenDosyaNumarasiniSessionaAtAction.do
        public void DosyaAc()
        {
            var dosyaNo = 076110120200800192;
            var bildirgeId = 876671;

            byte[] data = Encoding.ASCII.GetBytes($"dosyaNo={dosyaNo}&bildirgeId={bildirgeId}&");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/SecilenDosyaNumarasiniSessionaAtAction.do");
            request.Method = "POST";
            request.ContentType = "text/plain;charset=UTF-8";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }
            }
        }


        public void DosyaListele()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://uyg.sgk.gov.tr/TAKEP/pages/jsp/dosya_list.jsp? _ = {dateTime}");
            request.Method = "GET";
            request.ContentType = "text/plain;charset=UTF-8";
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string body = rdr.ReadToEnd(); // response from server

                    textArea.Text = body;
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(body);

                    var tableUsers = doc.GetElementbyId("users2");//.SelectNodes("//table/tr");
                    var nodes = tableUsers.SelectNodes("//table");
                    var dosyaListesi = new List<DosyaListe>();

                    //var headers = nodes[0].SelectNodes("//tr/th");
                    //foreach (var header in headers)
                    //{
                    //    table.Columns.Add(header.InnerHtml);
                    //}

                    var rows = nodes[0].SelectNodes("//tbody/tr");

                    foreach (var row in rows)
                    {
                        var id = row.Attributes["onclick"].Value;
                        var cells = row.SelectNodes("td");

                        dosyaListesi.Add(new DosyaListe
                        {
                            No = Convert.ToInt32(cells[0].InnerHtml),
                            SiraNo = cells[1].InnerHtml,
                            Donem = cells[2].InnerHtml,
                            Durum = cells[3].InnerHtml,
                            OlusturmaTarihi = cells[4].InnerHtml,
                            Sil = " - "
                        });

                        
                    }

                    lookUpEdit.Properties.DataSource = dosyaListesi.Select(x => x.SiraNo);
                }
            }
        }

        

        public void YeniDosyaOlustur()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var _dateTime = (long)t.TotalMilliseconds;
            byte[] data = Encoding.ASCII.GetBytes($"noncache={dateTime}&");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/pages/jsp/yeni_dosya_olustur_form.jsp");
            request.Method = "POST";
            request.ContentType = "text/plain;charset=UTF-8";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }
            }
        }
        public void AcikDosyaSayisiniKontrolEtAction()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/AcikDosyaSayisiniKontrolEtAction.do");
            request.Method = "POST"; request.ContentType = "text/plain;charset=UTF-8";
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }
            }
        }
        public void KesintiIcinUreticiSorgulaAction()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/GooKesintiIcinUreticiSorgulaAction.do");
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KesintiIcinUreticiSorgulaAction();
            AcikDosyaSayisiniKontrolEtAction();
            YeniDosyaOlustur();
            DosyaListele();

        }




        //sorgulama sonucu 11011 ise kesintiyapılacak
        public void KesintiFormunuGetir()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var _dateTime = (long)t.TotalMilliseconds;

            byte[] data = Encoding.ASCII.GetBytes($"noncache={_dateTime}");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/pages/jsp/tevkifat_kesinti_sayfasi2.jsp");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }
            }
        }

        public void KesintiListesiniGetir()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var _dateTime = (long)t.TotalMilliseconds;

            byte[] data = Encoding.ASCII.GetBytes($"noncache={_dateTime}");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/pages/jsp/tevkifatListesi.jsp");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }

                /*ABi burasını silme yapacagın zaman çalıştırman daha mantıklı*/
                /*Çünkü ekleme esnasında her seferinde dögüye sokmak mantıksız olur yükleme bittiklten sonra
                 bunu çalıştırt ve oradadm silinecekleri beilrle silme işlmini yapan fonksiyonu çalıştır*/
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string body = rdr.ReadToEnd();

                    textArea.Text = body;
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(body);

                    /*tevfikat listesi olan tabloyu alıyoruz*/
                    var tableUsers = doc.GetElementbyId("tevkifatList");
                    var nodes = tableUsers.SelectNodes("//table");//tablo başlığı gelir

                    var rows = nodes[0].SelectNodes("//tbody/tr");//tablo satırları gelir

                    foreach (var row in rows)
                    {
                        
                        /*burda her satırın hucreleri geliyor*/
                        var cells = row.SelectNodes("td");//burda her bir satırın hücreleri gelir
                        //9. hücre yani cells[8] ki metin içinde "/TAKEP/images/red-minus-sign.png"  varsa silinecek demektir
                        //burdaki değerleri cells[0], cells[1] şeklinde değerleri alıp datatable a basabiliriz
                        //içerisindei  metinleri düzenlemek gerekebilir abi senin becerine kalıyor o

                        //cells[9] yani son hücrede bir id var silme için gerkli onu almak gerekli adı detay id
                        //bu detay id ve daha önce cektiğimiz bildirge id ile gönderip silme işlmeini yapabiliriz



                    }

                    lookUpEdit.Properties.DataSource = dosyaListesi.Select(x => x.SiraNo);
                }

            }
        }

        public void KesintiIsleminiYap(int urunAlimBedeliTam, int urunAlimBedeliKrs, double netKesintiTutari, string odemeTarihi/*30.08.2020 ->şeklinde format*/, string tcNo)
        {
            //netKesintiTutari: 20,00
            //urunAlimBedeliTam: 1.000
            //urunAlimBedeliKrs: 0
            //odemeTarihi: 30.08.2020
            //tcNo: 26722118458

            KesintiFormunuGetir();

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var _dateTime = (long)t.TotalMilliseconds;

            //kesintiTutari
            byte[] data = Encoding.ASCII.GetBytes($"kesintiTutari={netKesintiTutari}" +
                                                  $"&urunAlimBedeliTam={urunAlimBedeliTam}" +
                                                  $"&urunAlimBedeliKrs={urunAlimBedeliKrs}" +
                                                  $"&odemeTarihi={odemeTarihi}" +
                                                  $"&tcNo={tcNo}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/TevkifatKesintisiYapAction.do");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string resultText = rdr.ReadToEnd(); // response from server

                    textArea.Text = resultText;

                    /*Burda gelen resultText içinde Okey varsa işlem başarılıdır*/
                }

                KesintiListesiniGetir();
                HerActionSonundaCalistir();

            }
        }

        public void KesintiIsleminiSil(int bildirgeId, int detayId)
        {
            //bildirgeId: 877071
            //detayId: 10680345

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var _dateTime = (long)t.TotalMilliseconds;

            //kesintiTutari
            byte[] data = Encoding.ASCII.GetBytes($"bildirgeId={bildirgeId}" +
                                                  $"&detayId={detayId}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uyg.sgk.gov.tr/TAKEP/TevkifatSilAction.do");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                    string resultText = rdr.ReadToEnd(); // response from server

                    textArea.Text = resultText;

                    /*Burda gelen resultText içinde Okey varsa işlem başarılıdır*/
                }

                KesintiListesiniGetir();
                HerActionSonundaCalistir();

            }
        }

        public void HerActionSonundaCalistir()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://uyg.sgk.gov.tr/TAKEP/GooKesintiIcinUreticiSorgulaAction.do");
            request.Method = "GET";
            request.CookieContainer = new CookieContainer();

            foreach (var item in BagkurHelper.cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {

                    if (BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        BagkurHelper.cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        BagkurHelper.cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }


                }

            }
        }
    }
    

}





