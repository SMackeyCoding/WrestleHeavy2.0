namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WrestleDetail1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wrestler", "PromotionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wrestler", "PromotionName");
        }
    }
}
