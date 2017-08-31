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
            return View(new WarViewModel{CurrentWar = apiCall.GetCurrentWar("#8UJGPROJ")});
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
                convertedTime = war.CurrentWar.EndTime.AddHours(-24);
            }
           
            //  var rawString =  war.EndTime.ToString();
            var rawString =  convertedTime.ToString();
             
            return Json(rawString.Substring(0, 17), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendWarPlan(string memberName, string warPlan)
        {
           queries.PopulateWarPlan(memberName, warPlan);
            return View("WarRoom", new WarViewModel{WarPlan = new WarPlanModel{MemberName = memberName, Plan = warPlan}});
        }
    }
}