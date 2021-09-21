namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210921updatedatabase : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.BackAccount",
            //    c => new
            //        {
            //            AdminID = c.Int(nullable: false, identity: true),
            //            Name = c.String(maxLength: 50),
            //            Email = c.String(maxLength: 50),
            //            Password = c.String(maxLength: 100),
            //            Account = c.String(maxLength: 50),
            //            Authority = c.Int(),
            //        })
            //    .PrimaryKey(t => t.AdminID);
            
            //CreateTable(
            //    "dbo.BackRole",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 450),
            //            Name = c.String(maxLength: 256),
            //            NormalizedName = c.String(maxLength: 256),
            //            ConcurrencyStamp = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.BackUserClaim",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            UserId = c.String(nullable: false, maxLength: 450),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.UserId });
            
            //CreateTable(
            //    "dbo.BackUserData",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 450),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(maxLength: 256),
            //            NormalizedUserName = c.String(maxLength: 256),
            //            Email = c.String(maxLength: 256),
            //            NormalizedEmail = c.String(maxLength: 256),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            ConcurrencyStamp = c.String(),
            //            PhoneNumber = c.String(),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.EmailConfirmed, t.PhoneNumberConfirmed, t.TwoFactorEnabled, t.LockoutEnabled, t.AccessFailedCount });
            
            //CreateTable(
            //    "dbo.BackUserLogin",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 450),
            //            ProviderDisplayName = c.String(),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            //CreateTable(
            //    "dbo.BackUserRole",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 450),
            //            RoleId = c.String(nullable: false, maxLength: 450),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            //CreateTable(
            //    "dbo.BackUserRoleClaim",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            RoleId = c.String(nullable: false, maxLength: 450),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.RoleId });
            
            //CreateTable(
            //    "dbo.BackUserToken",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 450),
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 128),
            //            Value = c.String(),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.Name });
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.RoleId, t.UserId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.RoleId);
            
            //AddColumn("dbo.Works", "Memo", c => c.String());
            //DropTable("dbo.AspNetUserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropColumn("dbo.Works", "Memo");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.BackUserToken");
            DropTable("dbo.BackUserRoleClaim");
            DropTable("dbo.BackUserRole");
            DropTable("dbo.BackUserLogin");
            DropTable("dbo.BackUserData");
            DropTable("dbo.BackUserClaim");
            DropTable("dbo.BackRole");
            DropTable("dbo.BackAccount");
            DropTable("dbo.AspNetRoles");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
