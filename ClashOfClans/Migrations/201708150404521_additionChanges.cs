namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MemberModels", newName: "Members");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Members", newName: "MemberModels");
        }
    }
}
