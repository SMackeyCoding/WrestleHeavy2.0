namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restart : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Title", new[] { "WrestlerId" });
            AlterColumn("dbo.Title", "WrestlerId", c => c.Int());
            CreateIndex("dbo.Title", "WrestlerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Title", new[] { "WrestlerId" });
            AlterColumn("dbo.Title", "WrestlerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Title", "WrestlerId");
        }
    }
}
