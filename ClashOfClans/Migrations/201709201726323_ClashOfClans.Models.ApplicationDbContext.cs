namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClashOfClansModelsApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MemberName", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
