namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlayerTag = c.String(),
                        Rank = c.Int(nullable: false),
                        League = c.String(),
                        Role = c.String(),
                        Level = c.Int(nullable: false),
                        Trophies = c.Int(nullable: false),
                        WarStars = c.Int(nullable: false),
                        TownHallLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
