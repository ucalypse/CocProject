﻿using System.Collections.Generic;
using System.Linq;
using ClashOfClans.Models;

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
        public void CreateAdmin()
        {
            MemberContext db = new MemberContext();
            using (db)
            {
                db.Admins.Add(new AdminModel {UserName = "admin", Password = "weedgood"});
                db.SaveChanges();
            }
        }
        public bool Authenticated(AdminModel admin)
        {
            MemberContext db = new MemberContext();
            var admins = db.Admins.ToList();
            var match = admins.Where(n => n.UserName == admin.UserName && n.Password == admin.Password).FirstOrDefault();
            if (match != null)
            {
                return true;
            }
            return false;
        }
         
        public void PopulateWarPlan(string memberName, string warPlan)
        {
            MemberContext db = new MemberContext();
            using (db)
            {
                db.WarPlans.Add(new WarPlanModel {MemberName = memberName, Plan = warPlan});
                db.SaveChanges();
            }
        }public void SaveVideo(string url, string description, string title)
        {
            MemberContext db = new MemberContext();
            using (db)
            {
                db.Videos.Add(new TutorialModel { URL = url, Description = description, VideoName = title});
                db.SaveChanges();
            }
        }
        public WarPlanModel GetWarPlan()
        {
            MemberContext db = new MemberContext();
            return db.WarPlans.OrderByDescending(x => x.Id).FirstOrDefault() ?? WarPlanModel.Empty();
        }

        public void ReserveTarget(string memberName, int target)
        {
            MemberContext db = new MemberContext();
            using (db)
            {
                db.Reservations.Add(new TargetReservationModel {MemberName = memberName, Target = target});
                db.SaveChanges();
            }
        }

        public TargetReservationModel GetTarget(int mapPosition)
        {
            MemberContext db = new MemberContext();
            var targetList = db.Reservations.ToList();
            foreach (var target in targetList)
            {
                if (target != null && target.Target == mapPosition)
                {
                    return target;
                }
            }
            return new TargetReservationModel();
        }

        public void ClearTargets()
        {
            MemberContext db = new MemberContext();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Reservations");
        }
        public static string RetrieveMemberName(string email)
        {
            ApplicationDbContext db = new ApplicationDbContext();
           
            var member = db.Users.Where(m => m.Email == email).SingleOrDefault();
            if (member != null)
            {
                return member.MemberName;
            }
            return "";
        }
        public List<TutorialModel> RetrieveVideos()
        {
            MemberContext db = new MemberContext();
            using (db)
            {
                return db.Videos.ToList();
            }
           
        }
        public void SubmitSuggestion(string suggestion)
        {
            MemberContext db = new MemberContext();
            using (db)
            {
                db.Suggestions.Add(new Suggestion {Feedback = suggestion});
                db.SaveChanges();
            }
        }
    }
}