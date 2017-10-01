namespace ClashOfClans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMappingTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UsernameMapper");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsernameMapper",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PlayerTag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
