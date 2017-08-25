using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ClashOfClans.ApiCalls;

namespace ClashOfClans.Data
{
    public class Queries
    {
        MemberMapper mapper = new MemberMapper();
        
        public void PopulateMembers(List<MemberModel> m)
        {
            MemberContext db = new MemberContext();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Members");
            using (db)
            {
                    db.Members.AddRange(m);
                    db.SaveChanges();
            }
        }
        public Member RetrieveMember(string playerTag)
        {
            MemberContext db = new MemberContext();
            var member = mapper.MapToMember(db.Members.Where(n => n.PlayerTag == playerTag).ToList());
            return member.First();
        }

        public List<MemberModel> GetAllMembers()
        {
            MemberContext db = new MemberContext();
            return db.Members.ToList();
        }

        public List<Member> FilterMembers(List<Member> filterList, int townHallLevel)
        {
            var filteredList = new List<Member>();
            foreach (var member in filterList)
            {
                if (member.TownHallLevel <= townHallLevel)
                {
                    filteredList.Add(member);
                }
            }
            return filteredList;
        }
    }
}