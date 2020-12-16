namespace Notepad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DueDate = c.DateTime(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "StatusId", "dbo.Status");
            DropIndex("dbo.Titles", new[] { "StatusId" });
            DropTable("dbo.Titles");
        }
    }
}
