using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Deserializers;

namespace ClashOfClans.ApiCalls
{
    public class Member
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }

        
    }
}