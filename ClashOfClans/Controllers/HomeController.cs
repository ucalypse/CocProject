using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClashOfClans.ApiCalls;
using ClashOfClans.Data;
using ClashOfClans.Models;

namespace ClashOfClans.Controllers
{
    public partial class HomeController : Controller
    {
        ApiCall apiCall = new ApiCall();
        Queries queries = new Queries();
        WarViewModel war = new WarViewModel();

        public ActionResult Index()
        {
            var view = new ClanListViewModel
            {
                Members = queries.GetAllMembers()
            };
            return View(view);
        }

        public ActionResult Tutorials()
        {
            ViewBag.Message = "Video Tutorials";

            return View();
        }

        public ActionResult WarRoom()
        {
            ViewBag.Message = " War Room";
            var warPlan = queries.GetWarPlan();
            var currentWar = apiCall.GetCurrentWar("#8UJGPROJ");
            if (currentWar.State == "preparation" | currentWar.State == "inWar")
            {
                currentWar.OpposingClan.MembersInWars = currentWar.OpposingClan.MembersInWars
                    .OrderBy(m => m.MapPosition).ToList();

                return View(new WarViewModel {CurrentWar = currentWar, WarPlan = warPlan});
            }
            else return View("Home", "NoWar");
        }

        [HttpGet]
        public void UpdateClanList()
        {
             apiCall.ClanApiCall();
        }

        [HttpGet]
        public JsonResult ConvertedDateTime()
        {
            war.CurrentWar = apiCall.GetCurrentWar("#8UJGPROJ");
            var convertedTime = war.CurrentWar.EndTime;
            
            if (war.CurrentWar.State == "preparation")
            {
                convertedTime = convertedTime.AddHours(-24);
            }
            var rawString =  convertedTime.ToString("MM/dd/yyyy HH:mm:ss");

            return Json(rawString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SendWarPlan(string memberName, string warPlan)
        {
           queries.PopulateWarPlan(memberName, warPlan);
            return Json(new WarViewModel{WarPlan = new WarPlanModel{MemberName = memberName, Plan = warPlan}}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAuthentication(string adminName, string adminPassword)
        {
            AdminModel admin = new AdminModel{Password = adminPassword, UserName = adminName};
            return Json(queries.Authenticated(admin), JsonRequestBehavior.AllowGet);
        }
    }
}