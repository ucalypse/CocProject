namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whoops : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "Rank");
            DropColumn("dbo.Members", "League");
            DropColumn("dbo.Members", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Role", c => c.String());
            AddColumn("dbo.Members", "League", c => c.String());
            AddColumn("dbo.Members", "Rank", c => c.Int(nullable: false));
        }
    }
}
