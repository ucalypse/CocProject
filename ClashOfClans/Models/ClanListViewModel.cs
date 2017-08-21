using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.ApiCalls;
using ClashOfClans.Data;
using RestSharp.Deserializers;

namespace ClashOfClans.Models
{
    public class ClanListViewModel
    {
        [DeserializeAs(Name = "items")]
        public List<MemberModel> Members { get; set; }
    }
}