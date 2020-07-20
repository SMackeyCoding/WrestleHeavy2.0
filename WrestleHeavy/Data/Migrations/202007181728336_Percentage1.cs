namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Percentage1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wrestler", "WinLossRatio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wrestler", "WinLossRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
