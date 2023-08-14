namespace Csharlink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        CreatorID = c.Int(nullable: false),
                        CreatorName = c.String(nullable: false),
                        Views = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropTable("dbo.Posts");
        }
    }
}
