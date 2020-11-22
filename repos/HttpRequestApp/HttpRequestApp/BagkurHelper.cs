using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestApp
{
    
    public class CookieValue
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public static class BagkurHelper
    {
        public static List<CookieValue> cookieValues;

        public void HerActionSonundaCalistir()
        {
            cookieValues = new List<CookieValue>();

            
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(@"https://uyg.sgk.gov.tr/TAKEP/GooKesintiIcinUreticiSorgulaAction.do");
            request1.Method = "GET";
            request1.CookieContainer = new CookieContainer();

            foreach (var item in cookieValues)
            {
                request1.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse())
            {
                foreach (Cookie cook in response1.Cookies)
                {
                    if(cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value=cook.Value;
                    }

                }
            }

            var res = cookieValues;

        }




        public static Image GetGuvenlikAnahtari()
        {
            RunFirstRequest();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://uyg.sgk.gov.tr/TAKEP/SayiUretenImage.do");
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; WOW64; " +
                "Trident/4.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; " +
                ".NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET CLR 3.0.30618; " +
                "InfoPath.2; OfficeLiveConnector.1.3; OfficeLivePatch.0.0)";
            request.CookieContainer = new CookieContainer();

            foreach (var item in cookieValues)
            {
                request.CookieContainer.Add(new Cookie(item.Name, item.Value, "/", "uyg.sgk.gov.tr"));
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                foreach (Cookie cook in response.Cookies)
                {
                    if (cookieValues.FirstOrDefault(x => x.Name == cook.Name) == null)
                    {
                        cookieValues.Add(new CookieValue
                        {
                            Name = cook.Name,
                            Value = cook.Value
                        });
                    }
                    else
                    {
                        cookieValues.FirstOrDefault(x => x.Name == cook.Name).Value = cook.Value;
                    }

                }

                Stream stream = response.GetResponseStream();
                Image img = Image.FromStream(stream);
                stream.Close();

                return img;

            }
            
        }


        










    }
}
