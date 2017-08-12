using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClashOfClans.Data
{
    public class Queries
    {
        MemberContext db = new MemberContext();
        public bool PopulateMembers(Member m)
        {
            using (db)
            {
                db.Members.Add(m);
                db.SaveChanges();
            }
            return true;
        }

        public Member RetrieveMember(string playerTag)
        {
            var query = db.Members.Where(n => n.PlayerTag == playerTag).Single();
            return query;
        }
    }
}