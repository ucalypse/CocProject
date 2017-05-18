using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ClashOfClans.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public object GetClanList(String clanTag)
        {
            //var getter = new HttpClient();
            //getter.BaseAddress = new Uri("https://api.clashofclans.com/v1/clans");
            //getter.
            string URI = "https://api.clashofclans.com/v1/clans";
            string myParameters = clan;
            var token =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjNlNDBkMGJlLTVjYzctNGI5ZS04NGNmLTFmZDExNGYwZDhhNyIsImlhdCI6MTQ5NTA1NzYwOSwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjI1NS4yNTUuMjU1LjAiXSwidHlwZSI6ImNsaWVudCJ9XX0.rDge_8Q85hs2mGxyCEfwWu1Er0va4Jsjdud77LxomjUgZ1T-S6K5UmobZyfgvvRta00p9RtJG2pFHc_54fCSLA";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "Authorization: Bearer " + token;
                string htmlResult = wc.UploadString(URI, myParameters);
                return htmlResult;
            }
        }
    }
}