namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingtutorials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TutorialModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        VideoName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TutorialModels");
        }
    }
}
