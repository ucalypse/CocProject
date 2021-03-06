using RestSharp.Deserializers;

namespace ClashOfClans
{
    public class MembersInWar
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "townhallLevel")]
        public int TownHallLevel { get; set; }

        [DeserializeAs(Name = "mapPosition")]
        public int MapPosition { get; set; }

        public string ReservedBy { get; set; }
    }
}