using Microsoft.WindowsAzure.Storage.Table;
using RestSharp.Deserializers;

namespace ClashOfClans
{
    public class Member : TableEntity
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "tag")]
        public string PlayerTag { get; set; }

        [DeserializeAs(Name = "clanRank")]
        public int Rank { get; set; }

        [DeserializeAs(Name = "league")]
        public string League { get; set; }

        [DeserializeAs(Name = "role")]
        public string Role { get; set; }

        [DeserializeAs(Name = "expLevel")]
        public int Level { get; set; }

        [DeserializeAs(Name = "trophies")]
        public int Trophies { get; set; }

        [DeserializeAs(Name = "warStars")]
        public int WarStars { get; set; }

        [DeserializeAs(Name = "townHallLevel")]
        public int TownHallLevel { get; set; }
    }
}