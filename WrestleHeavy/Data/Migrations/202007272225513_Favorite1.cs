namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorite1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Promotion", "IsStarred");
            DropColumn("dbo.Wrestler", "IsStarred");
            DropColumn("dbo.Title", "IsStarred");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Title", "IsStarred", c => c.Boolean(nullable: false));
            AddColumn("dbo.Wrestler", "IsStarred", c => c.Boolean(nullable: false));
            AddColumn("dbo.Promotion", "IsStarred", c => c.Boolean(nullable: false));
        }
    }
}
