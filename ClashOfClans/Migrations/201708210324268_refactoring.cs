namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Rank", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "League", c => c.String());
            AddColumn("dbo.Members", "Role", c => c.String());
            AddColumn("dbo.Members", "Level", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "Trophies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Trophies");
            DropColumn("dbo.Members", "Level");
            DropColumn("dbo.Members", "Role");
            DropColumn("dbo.Members", "League");
            DropColumn("dbo.Members", "Rank");
        }
    }
}
