using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.ApiCalls;

namespace ClashOfClans.Data
{
    public class Queries
    {
        MemberMapper mapper = new MemberMapper();
        MemberContext db = new MemberContext();
        public void PopulateMembers(List<MemberModel> m)
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Members");
            using (db)
            {
                    db.Database.Log = Console.WriteLine;
                    db.Members.AddRange(m);
                    db.SaveChanges();
            }
        }

        public Member RetrieveMember(string playerTag)
        {
            var member = mapper.MapToMember(db.Members.Where(n => n.PlayerTag == playerTag).ToList());
            return member.First();
        }

        public List<MemberModel> GetAllMembers()
        {
            return db.Members.ToList();
        }
    }
}