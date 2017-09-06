using ClashOfClans.Data;

namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClashOfClans.Data.MemberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClashOfClans.Data.MemberContext context)
        {
           context.Members.AddOrUpdate(new MemberModel{Level = 1, Name = "Wah", PlayerTag = "234", WarStars = 123, TownHallLevel = 11});
            context.Admins.AddOrUpdate(new AdminModel{Password = "weedgood", UserName = "admin"});
            context.WarPlans.AddOrUpdate(new WarPlanModel{MemberName = "Dada", Plan = "The new plan is awesome and it is great"});
        }
    }
}
