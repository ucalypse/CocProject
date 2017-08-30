namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renaming : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AdminModels", newName: "Admins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Admins", newName: "AdminModels");
        }
    }
}
