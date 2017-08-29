﻿using System;
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
        CurrentWar currentWar = new CurrentWar();

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
            return View(apiCall.GetCurrentWar("#8UJGPROJ"));
        }

        [HttpGet]
        public void UpdateClanList()
        {
             apiCall.ClanApiCall();
        }

        [HttpGet]
        public JsonResult ConvertedDateTime()
        {
            currentWar = apiCall.GetCurrentWar("#8UJGPROJ");
           // var convertedTime = currentWar.EndTime.AddHours();
            var rawString =  currentWar.EndTime.ToString();
             
            return Json(rawString.Substring(0, 17), JsonRequestBehavior.AllowGet);
        }
    }
}