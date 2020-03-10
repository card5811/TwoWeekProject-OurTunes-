namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "Profile");
            AlterColumn("dbo.Profile", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profile", "UserId", c => c.Guid(nullable: false));
            RenameTable(name: "dbo.Profile", newName: "User");
        }
    }
}
