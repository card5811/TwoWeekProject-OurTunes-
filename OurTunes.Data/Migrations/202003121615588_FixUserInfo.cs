namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Playlist", "OwnerId", "dbo.Profile");
            DropIndex("dbo.Playlist", new[] { "OwnerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Playlist", "OwnerId");
            AddForeignKey("dbo.Playlist", "OwnerId", "dbo.Profile", "OwnerId", cascadeDelete: true);
        }
    }
}
