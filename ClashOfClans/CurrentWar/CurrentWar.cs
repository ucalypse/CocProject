using System;
using System.Linq;
using System.Web;
using RestSharp.Deserializers;

namespace ClashOfClans
{
    public class CurrentWar
    {
        [DeserializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "startTime")]
        public DateTime StartTime { get; set; }

        [DeserializeAs(Name = "endTime")]
        public DateTime EndTime { get; set; }

        [DeserializeAs(Name = "clan")]
        public Clan OurClan { get; set; }

        [DeserializeAs(Name = "opponent")]
        public Clan OpposingClan { get; set; }
    }
   
}