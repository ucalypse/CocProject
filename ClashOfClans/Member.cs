using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Deserializers;

namespace ClashOfClans
{
    public class Member
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "clanRank")]
        public int Rank { get; set; }
    }
}