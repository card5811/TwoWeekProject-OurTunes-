namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigra : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Playlist", name: "UserId", newName: "OwnerId");
            RenameIndex(table: "dbo.Playlist", name: "IX_UserId", newName: "IX_OwnerId");
            AddColumn("dbo.User", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserId");
            RenameIndex(table: "dbo.Playlist", name: "IX_OwnerId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Playlist", name: "OwnerId", newName: "UserId");
        }
    }
}
