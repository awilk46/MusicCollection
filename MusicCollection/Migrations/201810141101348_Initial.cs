namespace MusicCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BandCD",
                c => new
                    {
                        BandCDId = c.Int(nullable: false, identity: true),
                        BandName = c.String(nullable: false),
                        AlbumName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BandCDId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        BandCDId = c.Int(nullable: false),
                        TrackName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.BandCD", t => t.BandCDId, cascadeDelete: true)
                .Index(t => t.BandCDId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Track", "BandCDId", "dbo.BandCD");
            DropIndex("dbo.Track", new[] { "BandCDId" });
            DropTable("dbo.Track");
            DropTable("dbo.BandCD");
        }
    }
}
