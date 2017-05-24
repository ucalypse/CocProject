using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace ClashOfClans.ApiCalls
{
    public class Clan
    {
        [DeserializeAs(Name = "items")]
        public List<Member> Members { get; set; }

    }
}