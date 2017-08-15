using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClashOfClans.Data
{
    [Table("Members")]
    public class MemberModel
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string PlayerTag { get; set; }
        public int WarStars { get; set; }
        public int TownHallLevel { get; set; }
        
    }
}