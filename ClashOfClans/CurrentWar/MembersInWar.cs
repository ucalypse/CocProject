using RestSharp.Deserializers;

namespace ClashOfClans
{
    public class MembersInWar
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "townHallLevel")]
        public int TownHallLevel { get; set; }

        [DeserializeAs(Name = "mapPosition")]
        public int MapPosition { get; set; }
    }
}