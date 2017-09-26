namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsernameMapper", "PlayerTag", c => c.String());
            DropColumn("dbo.UsernameMapper", "MemberName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsernameMapper", "MemberName", c => c.String());
            DropColumn("dbo.UsernameMapper", "PlayerTag");
        }
    }
}
