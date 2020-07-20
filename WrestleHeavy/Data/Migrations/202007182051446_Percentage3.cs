namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Percentage3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Wrestler", "WinLossRatio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wrestler", "WinLossRatio", c => c.Double(nullable: false));
        }
    }
}
