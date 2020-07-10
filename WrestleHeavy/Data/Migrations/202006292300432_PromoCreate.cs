namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromoCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Promotion", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotion", "MyProperty", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Promotion", "CreatedUtc");
        }
    }
}
