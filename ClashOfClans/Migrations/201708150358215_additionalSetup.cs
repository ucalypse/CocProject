namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalSetup : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Members", newName: "MemberModels");
            DropColumn("dbo.MemberModels", "Trophies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberModels", "Trophies", c => c.Int(nullable: false));
            RenameTable(name: "dbo.MemberModels", newName: "Members");
        }
    }
}
