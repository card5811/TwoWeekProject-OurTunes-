namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeRateasong : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Song", "RateAdverage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongRating", "SongId", "dbo.Song");
            DropIndex("dbo.SongRating", new[] { "SongId" });
            DropColumn("dbo.Song", "RateAdverage");
            DropTable("dbo.SongRating");
        }
    }
}
