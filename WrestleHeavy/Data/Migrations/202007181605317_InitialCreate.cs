namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promotion",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PromotionName = c.String(nullable: false),
                        DateFounded = c.DateTime(nullable: false),
                        Website = c.String(nullable: false),
                        IsStarred = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.Wrestler",
                c => new
                    {
                        WrestlerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RingName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.Int(nullable: false),
                        PromotionId = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        WinLossRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsChampion = c.Boolean(nullable: false),
                        TitleId = c.Int(),
                        IsStarred = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.WrestlerId)
                .ForeignKey("dbo.Promotion", t => t.PromotionId)
                .ForeignKey("dbo.Title", t => t.TitleId)
                .Index(t => t.PromotionId)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        TitleName = c.String(nullable: false),
                        DateEstablished = c.DateTime(nullable: false),
                        PromotionId = c.Int(nullable: false),
                        WrestlerId = c.Int(),
                        IsStarred = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Title_Id = c.Int(),
                        Wrestler_WrestlerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotion", t => t.PromotionId)
                .ForeignKey("dbo.Title", t => t.Title_Id)
                .ForeignKey("dbo.Wrestler", t => t.WrestlerId)
                .ForeignKey("dbo.Wrestler", t => t.Wrestler_WrestlerId)
                .Index(t => t.PromotionId)
                .Index(t => t.WrestlerId)
                .Index(t => t.Title_Id)
                .Index(t => t.Wrestler_WrestlerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropForeignKey("dbo.Title", "WrestlerId", "dbo.Wrestler");
            DropForeignKey("dbo.Title", "Title_Id", "dbo.Title");
            DropForeignKey("dbo.Title", "PromotionId", "dbo.Promotion");
            DropForeignKey("dbo.Wrestler", "PromotionId", "dbo.Promotion");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Title", new[] { "Wrestler_WrestlerId" });
            DropIndex("dbo.Title", new[] { "Title_Id" });
            DropIndex("dbo.Title", new[] { "WrestlerId" });
            DropIndex("dbo.Title", new[] { "PromotionId" });
            DropIndex("dbo.Wrestler", new[] { "TitleId" });
            DropIndex("dbo.Wrestler", new[] { "PromotionId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Title");
            DropTable("dbo.Wrestler");
            DropTable("dbo.Promotion");
        }
    }
}
