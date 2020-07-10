namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDownDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion", "Wrestler_WrestlerId", c => c.Int());
            CreateIndex("dbo.Promotion", "Wrestler_WrestlerId");
            AddForeignKey("dbo.Promotion", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promotion", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropIndex("dbo.Promotion", new[] { "Wrestler_WrestlerId" });
            DropColumn("dbo.Promotion", "Wrestler_WrestlerId");
        }
    }
}
