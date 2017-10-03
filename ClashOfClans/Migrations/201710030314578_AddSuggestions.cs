namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuggestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suggestions");
        }
    }
}
