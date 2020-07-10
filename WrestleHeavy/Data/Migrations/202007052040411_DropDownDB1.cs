namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDownDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion", "PromotionName", c => c.String(nullable: false));
            DropColumn("dbo.Promotion", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotion", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Promotion", "PromotionName");
        }
    }
}
