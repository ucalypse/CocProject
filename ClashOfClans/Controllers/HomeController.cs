using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClashOfClans.ApiCalls;

namespace ClashOfClans.Controllers
{
    public partial class HomeController : Controller
    {
        ApiCall apiCall = new ApiCall();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About our clan";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}