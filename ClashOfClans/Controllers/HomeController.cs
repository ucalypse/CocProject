using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClashOfClans.ApiCalls;
using ClashOfClans.Data;
using ClashOfClans.Models;
using Microsoft.AspNet.Identity;

namespace ClashOfClans.Controllers
{
    public partial class HomeController : Controller
    {
        ApiCall apiCall = new ApiCall();
        Queries queries = new Queries();
        WarViewModel war = new WarViewModel();
        MakeReservation reservation = new MakeReservation();

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
        [Authorize]
        public ActionResult WarRoom()
        {
            var currentUser = User.Identity.Name;
            ViewBag.Message = "War Room";
            var warPlan = queries.GetWarPlan();
            var currentWar = apiCall.GetCurrentWar("#8UJGPROJ");
            if (currentWar.State == "preparation" | currentWar.State == "inWar")
            {
                currentWar.OpposingClan.MembersInWars = reservation.AssignTargets(currentWar.OpposingClan.MembersInWars);

                return View(BuildWarViewModel(currentWar, warPlan));
            }
            queries.ClearTargets();
            return View("NoWar");
        }

        private WarViewModel BuildWarViewModel(CurrentWar currentWar, WarPlanModel warPlan)
        {
            var memberName = Queries.RetrieveMemberName(User.Identity.GetUserName());
            return new WarViewModel {CurrentWar = currentWar, WarPlan = warPlan, MemberName = memberName};
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

        [HttpPost]
        public void ReserveTarget(int target)
        {
            var memberName = Queries.RetrieveMemberName(User.Identity.GetUserName());
            queries.ReserveTarget(memberName, target);
        }

        [HttpGet]
        public void ClearTargets()
        {
            queries.ClearTargets();
        }
        [Authorize]
        public ActionResult Suggestions()
        {
            return View();
        }
        public void SubmitSuggestion(string suggestion)
        {
            queries.SubmitSuggestion(suggestion);
        }
    }
}