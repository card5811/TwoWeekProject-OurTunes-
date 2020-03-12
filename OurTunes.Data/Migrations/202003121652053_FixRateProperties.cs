namespace OurTunes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRateProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Song", "RateAdverage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Song", "RateAdverage", c => c.Double(nullable: false));
        }
    }
}
