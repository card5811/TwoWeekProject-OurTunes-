namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenre : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "Profile");
            RenameColumn(table: "dbo.Playlist", name: "UserId", newName: "OwnerId");
            RenameIndex(table: "dbo.Playlist", name: "IX_UserId", newName: "IX_OwnerId");
            AddColumn("dbo.Song", "SongGenre", c => c.String(nullable: false));
            AlterColumn("dbo.Profile", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profile", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Song", "SongGenre");
            RenameIndex(table: "dbo.Playlist", name: "IX_OwnerId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Playlist", name: "OwnerId", newName: "UserId");
            RenameTable(name: "dbo.Profile", newName: "User");
        }
    }
}
