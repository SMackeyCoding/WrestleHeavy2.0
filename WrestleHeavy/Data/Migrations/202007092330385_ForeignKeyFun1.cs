namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyFun1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Promotion", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropIndex("dbo.Promotion", new[] { "Wrestler_WrestlerId" });
            DropColumn("dbo.Promotion", "Wrestler_WrestlerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotion", "Wrestler_WrestlerId", c => c.Int());
            CreateIndex("dbo.Promotion", "Wrestler_WrestlerId");
            AddForeignKey("dbo.Promotion", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId");
        }
    }
}
