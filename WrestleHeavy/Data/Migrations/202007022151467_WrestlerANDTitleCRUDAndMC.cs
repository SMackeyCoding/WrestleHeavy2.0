namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WrestlerANDTitleCRUDAndMC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        TitleName = c.String(nullable: false),
                        DateEstablished = c.DateTimeOffset(nullable: false, precision: 7),
                        IsStarred = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TitleId);
            
            CreateTable(
                "dbo.Wrestler",
                c => new
                    {
                        WrestlerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RingName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        Nationality = c.Int(nullable: false),
                        PromotionId = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        WinLossRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsChampion = c.Boolean(nullable: false),
                        TitleId = c.Int(),
                        IsStarred = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.WrestlerId)
                .ForeignKey("dbo.Promotion", t => t.PromotionId, cascadeDelete: true)
                .ForeignKey("dbo.Title", t => t.TitleId)
                .Index(t => t.PromotionId)
                .Index(t => t.TitleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropForeignKey("dbo.Wrestler", "PromotionId", "dbo.Promotion");
            DropIndex("dbo.Wrestler", new[] { "TitleId" });
            DropIndex("dbo.Wrestler", new[] { "PromotionId" });
            DropTable("dbo.Wrestler");
            DropTable("dbo.Title");
        }
    }
}
