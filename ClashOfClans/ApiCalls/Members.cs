using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Deserializers;

namespace ClashOfClans.ApiCalls
{
    public class Members
    {
        [DeserializeAs(Name = "items")]
        public List<Member> People { get; set; }
    }
}                               