namespace Csharlink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Title", c => c.Int(nullable: false));
        }
    }
}
