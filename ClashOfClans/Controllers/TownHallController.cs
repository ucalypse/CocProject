using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClashOfClans.ApiCalls;
using ClashOfClans.Models;
using Newtonsoft.Json;

namespace ClashOfClans.Controllers
{
    public class TownHallController : Controller
    {

        ApiCall apiCall = new ApiCall();
        // GET: TownHall
        public ActionResult ThreeThrough6()
        {
            var members = apiCall.GetOurClan();
            var membersWithInfo = new List<Member>();
            foreach (var member in members)
            {
                membersWithInfo.Add(apiCall.GetPlayerInfo(member.PlayerTag));
                
            }

            var filteredList = apiCall.FilterMembers(membersWithInfo, 6);

            return View(filteredList);
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