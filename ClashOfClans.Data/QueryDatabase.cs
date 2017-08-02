using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClashOfClans.Data
{
    public class QueryDatabase
    {
        public void AddMember(Member m)
        {
            using (var ctx = new MemberContext())
            {
                Member member = m;

                ctx.Members.Add(member);
                ctx.SaveChanges();
            }
        }
    }
}