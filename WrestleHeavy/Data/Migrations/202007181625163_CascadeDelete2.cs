namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TitleWrestler", "Title_Id", "dbo.Title");
            DropForeignKey("dbo.TitleWrestler", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropIndex("dbo.TitleWrestler", new[] { "Title_Id" });
            DropIndex("dbo.TitleWrestler", new[] { "Wrestler_WrestlerId" });
            DropTable("dbo.TitleWrestler");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TitleWrestler",
                c => new
                    {
                        Title_Id = c.Int(nullable: false),
                        Wrestler_WrestlerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Title_Id, t.Wrestler_WrestlerId });
            
            CreateIndex("dbo.TitleWrestler", "Wrestler_WrestlerId");
            CreateIndex("dbo.TitleWrestler", "Title_Id");
            AddForeignKey("dbo.TitleWrestler", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId", cascadeDelete: true);
            AddForeignKey("dbo.TitleWrestler", "Title_Id", "dbo.Title", "Id", cascadeDelete: true);
        }
    }
}
