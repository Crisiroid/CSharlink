namespace Csharlink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AccessType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AccessType");
        }
    }
}
