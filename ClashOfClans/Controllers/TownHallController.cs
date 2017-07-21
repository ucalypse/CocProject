using ClashOfClans.ApiCalls;
using ClashOfClans.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClashOfClans.Controllers
{
    public class TownHallController : Controller
    {

        ApiCall apiCall = new ApiCall();
        QueryTable queryTable = new QueryTable();

        // GET: TownHall
        public ActionResult ThreeThrough6()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetFilteredList()
        {
            var members = apiCall.GetOurClan();
            var membersWithInfo = new List<Member>();

            foreach (var member in members)
            {
                membersWithInfo.Add(queryTable.GetPlayerInfo(member.PlayerTag));
            }

            var filteredList = apiCall.FilterMembers(membersWithInfo, 6);

            var model = new ClanListViewModel
            {
                Members = filteredList
            };

            return Json(model, JsonRequestBehavior.AllowGet);
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