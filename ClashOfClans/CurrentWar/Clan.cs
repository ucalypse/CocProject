using System.Collections.Generic;
using RestSharp.Deserializers;

namespace ClashOfClans
{
    public class Clan
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "members")]
        public List<MembersInWar> MembersInWars { get; set; }

        [DeserializeAs(Name = "attacks")]
        public int AttacksDone { get; set; }

        [DeserializeAs(Name = "stars")]
        public int Stars { get; set; }

        [DeserializeAs(Name = "desturctionPercentage")]
        public decimal Destruction { get; set; }

      
    }
}