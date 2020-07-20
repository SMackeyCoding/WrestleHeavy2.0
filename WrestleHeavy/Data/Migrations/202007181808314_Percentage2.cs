namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Percentage2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wrestler", "WinLossRatio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wrestler", "WinLossRatio", c => c.Int(nullable: false));
        }
    }
}
