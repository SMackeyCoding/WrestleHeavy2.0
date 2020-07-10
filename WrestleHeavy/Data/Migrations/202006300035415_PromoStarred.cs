namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromoStarred : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion", "IsStarred", c => c.Boolean(nullable: false));
            DropColumn("dbo.Promotion", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotion", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Promotion", "IsStarred");
        }
    }
}
