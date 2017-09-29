using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Data;

namespace ClashOfClans.Models
{
    public class WarViewModel
    {
        public CurrentWar CurrentWar { get; set; }
        public WarPlanModel WarPlan { get; set; }
        public string MemberName { get; set; }
    }
}