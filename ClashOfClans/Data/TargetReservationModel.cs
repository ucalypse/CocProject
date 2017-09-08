using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClashOfClans.Data
{
    [Table("Reservations")]
    public class TargetReservationModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public int Target { get; set; }
    }
}