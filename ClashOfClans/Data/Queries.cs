using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClashOfClans.Data
{
    public class Queries
    {
        MemberContext db = new MemberContext();
        public void PopulateMembers(List<Member> m)
        {
            using (db)
            {
                foreach (var item in m)
                {
                    db.Members.Add(item);
                    db.SaveChanges();
                }
            }
        }

        public Member RetrieveMember(string playerTag)
        {
            var query = db.Members.Where(n => n.PlayerTag == playerTag).Single();
            return query;
        }
    }
}