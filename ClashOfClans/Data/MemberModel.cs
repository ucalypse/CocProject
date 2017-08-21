using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestSharp.Deserializers;

namespace ClashOfClans.Data
{
    [Table("Members")]
    public class MemberModel
    {
        [Key]
        public int MemberId { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "tag")]
        public string PlayerTag { get; set; }

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