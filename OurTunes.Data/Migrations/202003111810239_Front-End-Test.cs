namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FrontEndTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Playlist", "TotalTimeOfPlaylist", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Playlist", "TotalTimeOfPlaylist", c => c.String());
        }
    }
}
