namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKResolution3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropIndex("dbo.Wrestler", new[] { "TitleId" });
            AddColumn("dbo.Title", "WrestlerId", c => c.Int());
            CreateIndex("dbo.Title", "WrestlerId");
            AddForeignKey("dbo.Title", "WrestlerId", "dbo.Wrestler", "WrestlerId");
            DropColumn("dbo.Wrestler", "TitleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wrestler", "TitleId", c => c.Int());
            DropForeignKey("dbo.Title", "WrestlerId", "dbo.Wrestler");
            DropIndex("dbo.Title", new[] { "WrestlerId" });
            DropColumn("dbo.Title", "WrestlerId");
            CreateIndex("dbo.Wrestler", "TitleId");
            AddForeignKey("dbo.Wrestler", "TitleId", "dbo.Title", "Id");
        }
    }
}
