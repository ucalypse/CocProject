using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Data;

namespace ClashOfClans
{
    public class MakeReservation
    {
        Queries queries = new Queries();
        public List<MembersInWar> AssignTargets(List<MembersInWar> preAssigned)
        {
            var assignedList = preAssigned;

            foreach (var member in assignedList)
            {
                member.ReservedBy = queries.GetTarget(member.MapPosition).MemberName;
            }
            return assignedList.OrderBy(m => m.MapPosition).ToList();
        }
    }
}