using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.ApiCalls;

namespace ClashOfClans.Models
{
    public class ClanListViewModel
    {
        public List<Member> Members { get; set; }
        

        //public List<Member> GetMembers()
        //{
        //    var apiCalls = new ApiCalls.ApiCalls();
        //    return apiCalls.GetOurClan();
        //}
    }
}