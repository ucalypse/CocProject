using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClashOfClans.Data
{
    [Table("UsernameMapper")]
    public class MapEmailToMemberNameModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PlayerTag { get; set; }
    }
}