namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Title", "WrestlerId", "dbo.Wrestler");
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            AddColumn("dbo.Wrestler", "Title_Id", c => c.Int());
            AddColumn("dbo.Title", "Wrestler_WrestlerId", c => c.Int());
            CreateIndex("dbo.Wrestler", "Title_Id");
            CreateIndex("dbo.Title", "Wrestler_WrestlerId");
            AddForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId");
            AddForeignKey("dbo.Wrestler", "Title_Id", "dbo.Title", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wrestler", "Title_Id", "dbo.Title");
            DropForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropIndex("dbo.Title", new[] { "Wrestler_WrestlerId" });
            DropIndex("dbo.Wrestler", new[] { "Title_Id" });
            DropColumn("dbo.Title", "Wrestler_WrestlerId");
            DropColumn("dbo.Wrestler", "Title_Id");
            AddForeignKey("dbo.Wrestler", "TitleId", "dbo.Title", "Id");
            AddForeignKey("dbo.Title", "WrestlerId", "dbo.Wrestler", "WrestlerId");
        }
    }
}
