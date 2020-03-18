namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Playlist", "OwnerId", "dbo.Profile");
            DropIndex("dbo.Playlist", new[] { "OwnerId" });
            CreateTable(
                "dbo.SongRating",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        SongRate = c.Double(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RateId)
                .ForeignKey("dbo.Song", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
            AddColumn("dbo.Song", "SongGenre", c => c.String(nullable: false));
            AddColumn("dbo.Song", "RateAdverage", c => c.String());
            AddColumn("dbo.Song", "RateAverage", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongRating", "SongId", "dbo.Song");
            DropIndex("dbo.SongRating", new[] { "SongId" });
            DropColumn("dbo.Song", "RateAverage");
            DropColumn("dbo.Song", "RateAdverage");
            DropColumn("dbo.Song", "SongGenre");
            DropTable("dbo.SongRating");
            CreateIndex("dbo.Playlist", "OwnerId");
            AddForeignKey("dbo.Playlist", "OwnerId", "dbo.Profile", "OwnerId", cascadeDelete: true);
        }
    }
}
