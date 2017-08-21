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
        Queries queries = new Queries();
        MemberMapper mapper = new MemberMapper();

        public ActionResult Index()
        {
            var view = new ClanListViewModel
            {
                Members = mapper.MapToMemberModel(queries.GetAllMembers())
            };
            return View(view);
        }

        public ActionResult Tutorials()
        {
            ViewBag.Message = "Video Tutorials";

            return View();
        }
    }
}