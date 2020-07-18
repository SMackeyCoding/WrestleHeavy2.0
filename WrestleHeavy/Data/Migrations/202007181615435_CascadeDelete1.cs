namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropIndex("dbo.Title", new[] { "Wrestler_WrestlerId" });
            CreateTable(
                "dbo.TitleWrestler",
                c => new
                    {
                        Title_Id = c.Int(nullable: false),
                        Wrestler_WrestlerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Title_Id, t.Wrestler_WrestlerId })
                .ForeignKey("dbo.Title", t => t.Title_Id, cascadeDelete: true)
                .ForeignKey("dbo.Wrestler", t => t.Wrestler_WrestlerId, cascadeDelete: true)
                .Index(t => t.Title_Id)
                .Index(t => t.Wrestler_WrestlerId);
            
            DropColumn("dbo.Title", "Wrestler_WrestlerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Title", "Wrestler_WrestlerId", c => c.Int());
            DropForeignKey("dbo.TitleWrestler", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropForeignKey("dbo.TitleWrestler", "Title_Id", "dbo.Title");
            DropIndex("dbo.TitleWrestler", new[] { "Wrestler_WrestlerId" });
            DropIndex("dbo.TitleWrestler", new[] { "Title_Id" });
            DropTable("dbo.TitleWrestler");
            CreateIndex("dbo.Title", "Wrestler_WrestlerId");
            AddForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId");
        }
    }
}
