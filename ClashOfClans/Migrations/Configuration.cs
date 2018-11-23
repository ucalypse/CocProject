using ClashOfClans.Data;

namespace ClashOfClans.Migrations
{
    using System;
    using System.Collections.Generic;
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
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Admins");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE WarPlanModels");
            context.Admins.AddOrUpdate(new AdminModel{Password = "weedgood", UserName = "admin"});
            context.WarPlans.AddOrUpdate(new WarPlanModel{MemberName = "Dada", Plan = "The new plan is awesome and it is great"});
            //context.Videos.AddOrUpdate(
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/lUCdBPDnCc8",
            //        Description = "Town Hall 9",
            //        VideoName = "LavaLoon Attack Strategy - Dada"
            //    },
            //    new TutorialModel
            //    {
            //        URL= "https://youtu.be/4zVmrvYnhsg",
            //        Description = "Town Hall 9",
            //        VideoName = "AQ Walk With Bowlers - Ekmurf"
            //    },
            //    new TutorialModel
            //    {
            //        URL= "https://youtu.be/bW5ro0PAqjY",
            //        Description = "Town Hall 9",
            //        VideoName = "Traditional Valk Attack - Dada"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/gfVRIUFcFJk",
            //        Description = "Town Hall 8",
            //        VideoName = "Hogs - Dada"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/guza35tj3Mg",
            //        Description = "Lower Town Halls",
            //        VideoName = "Lower Level Guide - Dada - TH4-6"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/WO3_eo13Tdk",
            //        Description = "Town Hall 9 & 10",
            //        VideoName = "Th9 and 10 Farming - Lil Boy"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/qDfvVssnAws",
            //        Description = "Town Hall 9",
            //        VideoName = "GOHO - Jam"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/bVKMrSt0Aog",
            //        Description = "Town Hall 11",
            //        VideoName = "AQ Walk With Hogs - Dada"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/7lBQyjjZsmc",
            //        Description = "Lower Town Halls",
            //        VideoName = "Beginner Farming - BossBitch"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/kv-Ph9iDAHY",
            //        Description = "Town Hall 11",
            //        VideoName = "AQ Walk With Bowlers - Dada"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/ieXp3IGA9lU",
            //        Description = "Town Hall 11",
            //        VideoName = "Advanced Troop Draw - Dada"
            //    },
            //    new TutorialModel
            //    {
            //        URL = "https://youtu.be/LNwtHmSrZqA",
            //        Description = "Town Hall 11",
            //        VideoName = "Pekka Bowler - Dada"
            //    });
        }
    }
}
