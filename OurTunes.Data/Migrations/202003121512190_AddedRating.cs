namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JointPlaylist",
                c => new
                    {
                        JointId = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JointId)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Song", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        TotalTimeOfPlaylist = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistId)
                .ForeignKey("dbo.Profile", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        UserName = c.String(nullable: false),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false),
                        SongName = c.String(nullable: false),
                        AlbumName = c.String(nullable: false),
                        SongLength = c.String(nullable: false),
                        SongGenre = c.String(nullable: false),
                        SongRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SongId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.JointPlaylist", "SongId", "dbo.Song");
            DropForeignKey("dbo.JointPlaylist", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Playlist", "OwnerId", "dbo.Profile");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Playlist", new[] { "OwnerId" });
            DropIndex("dbo.JointPlaylist", new[] { "PlaylistId" });
            DropIndex("dbo.JointPlaylist", new[] { "SongId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Song");
            DropTable("dbo.Profile");
            DropTable("dbo.Playlist");
            DropTable("dbo.JointPlaylist");
        }
    }
}
