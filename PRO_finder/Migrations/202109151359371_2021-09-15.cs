namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210915 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.Case", "MemberID", "dbo.MemberInfo");
            //DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId);
            
            //CreateTable(
            //    "dbo.Banner",
            //    c => new
            //        {
            //            BannerID = c.Int(nullable: false, identity: true),
            //            BannerTitle = c.String(maxLength: 50),
            //            BannerImgUrl = c.String(),
            //        })
            //    .PrimaryKey(t => t.BannerID);
            
            //CreateTable(
            //    "dbo.FeaturedWork",
            //    c => new
            //        {
            //            FeaturedID = c.Int(nullable: false, identity: true),
            //            WorkID = c.Int(),
            //            Memo = c.String(),
            //        })
            //    .PrimaryKey(t => t.FeaturedID)
            //    .ForeignKey("dbo.Works", t => t.WorkID)
            //    .Index(t => t.WorkID);
            
            //AddColumn("dbo.Works", "Featured", c => c.Int());
            //DropTable("dbo.AspNetRoles");
            //DropTable("dbo.AspNetUserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.FeaturedWork", "WorkID", "dbo.Works");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FeaturedWork", new[] { "WorkID" });
            DropColumn("dbo.Works", "Featured");
            DropTable("dbo.FeaturedWork");
            DropTable("dbo.Banner");
            DropTable("dbo.AspNetUserRoles");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            AddForeignKey("dbo.Case", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
