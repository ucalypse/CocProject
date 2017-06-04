using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClashOfClans.ApiCalls;

namespace ClashOfClans.Controllers
{
    public class TownHallController : Controller
    {

        ApiCall apiCall = new ApiCall();
        // GET: TownHall
        public ActionResult ThreeThrough6()
        {
            var result = apiCall.GetOurClan().Where(s => s.Rank == 1);

            return View(result);
        }
        public ActionResult TownHall7()
        {
            return View();
        }
        public ActionResult TownHall8()
        {
            return View();
        }
        public ActionResult TownHall9()
        {
            return View();
        }
        public ActionResult TownHall10()
        {
            return View();
        }
    }
}