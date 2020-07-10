namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKResolution1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Title", "Title_Id", "dbo.Title");
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropPrimaryKey("dbo.Title");
            DropColumn("dbo.Title", "TitleId");
            AddColumn("dbo.Promotion", "Promotion_PromotionId", c => c.Int());
            AddColumn("dbo.Title", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Title", "PromotionId", c => c.Int(nullable: false));
            AddColumn("dbo.Title", "Title_Id", c => c.Int());
            AddColumn("dbo.Wrestler", "Wrestler_WrestlerId", c => c.Int());
            AddPrimaryKey("dbo.Title", "Id");
            CreateIndex("dbo.Promotion", "Promotion_PromotionId");
            CreateIndex("dbo.Title", "PromotionId");
            CreateIndex("dbo.Title", "Title_Id");
            CreateIndex("dbo.Wrestler", "Wrestler_WrestlerId");
            AddForeignKey("dbo.Promotion", "Promotion_PromotionId", "dbo.Promotion", "PromotionId");
            AddForeignKey("dbo.Title", "PromotionId", "dbo.Promotion", "PromotionId", cascadeDelete: true);
            AddForeignKey("dbo.Title", "Title_Id", "dbo.Title", "Id");
            AddForeignKey("dbo.Wrestler", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId");
            AddForeignKey("dbo.Wrestler", "TitleId", "dbo.Title", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Title", "TitleId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropForeignKey("dbo.Wrestler", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropForeignKey("dbo.Title", "Title_Id", "dbo.Title");
            DropForeignKey("dbo.Title", "PromotionId", "dbo.Promotion");
            DropForeignKey("dbo.Promotion", "Promotion_PromotionId", "dbo.Promotion");
            DropIndex("dbo.Wrestler", new[] { "Wrestler_WrestlerId" });
            DropIndex("dbo.Title", new[] { "Title_Id" });
            DropIndex("dbo.Title", new[] { "PromotionId" });
            DropIndex("dbo.Promotion", new[] { "Promotion_PromotionId" });
            DropPrimaryKey("dbo.Title");
            DropColumn("dbo.Wrestler", "Wrestler_WrestlerId");
            DropColumn("dbo.Title", "Title_Id");
            DropColumn("dbo.Title", "PromotionId");
            DropColumn("dbo.Title", "Id");
            DropColumn("dbo.Promotion", "Promotion_PromotionId");
            AddPrimaryKey("dbo.Title", "TitleId");
            AddForeignKey("dbo.Wrestler", "TitleId", "dbo.Title", "Id");
            AddForeignKey("dbo.Title", "Title_Id", "dbo.Title", "Id");
        }
    }
}
