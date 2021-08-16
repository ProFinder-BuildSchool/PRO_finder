namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBtest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotation", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Quotation", "OtherPictureID", "dbo.OtherPicture");
            DropForeignKey("dbo.OtherPicture", "QuotationID", "dbo.Quotation");
            DropIndex("dbo.Quotation", new[] { "OtherPictureID" });
            DropIndex("dbo.Quotation", new[] { "LocationID" });
            DropIndex("dbo.OtherPicture", new[] { "QuotationID" });
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);

            //AddColumn("dbo.MemberInfo", "IsThirdLogin", c => c.Byte());
            //AddColumn("dbo.Works", "WebsiteURL", c => c.String());
            //AddColumn("dbo.Order", "DealedDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Quotation", "Price", c => c.Decimal(precision: 5, scale: 0));
            AlterColumn("dbo.OtherPicture", "OtherPicture", c => c.String());
            AlterColumn("dbo.Works", "WorkName", c => c.String(nullable: false));
            AlterColumn("dbo.Works", "Client", c => c.String(nullable: false));
            AlterColumn("dbo.Works", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.WorkPictures", "WorkPicture", c => c.String(nullable: false));
            //DropColumn("dbo.Quotation", "LocationID");
            //DropColumn("dbo.Works", "WebsiteURLID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Works", "WebsiteURLID", c => c.String());
            AddColumn("dbo.Quotation", "LocationID", c => c.Int());
            AlterColumn("dbo.WorkPictures", "WorkPicture", c => c.Binary(nullable: false, storeType: "image"));
            AlterColumn("dbo.Works", "Role", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Works", "Client", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Works", "WorkName", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.OtherPicture", "OtherPicture", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.Quotation", "Price", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Order", "DealedDate");
            DropColumn("dbo.Works", "WebsiteURL");
            DropColumn("dbo.MemberInfo", "IsThirdLogin");
            DropTable("dbo.sysdiagrams");
            CreateIndex("dbo.OtherPicture", "QuotationID");
            CreateIndex("dbo.Quotation", "LocationID");
            CreateIndex("dbo.Quotation", "OtherPictureID");
            AddForeignKey("dbo.OtherPicture", "QuotationID", "dbo.Quotation", "QuotationID");
            AddForeignKey("dbo.Quotation", "OtherPictureID", "dbo.OtherPicture", "OtherPictureID");
            AddForeignKey("dbo.Quotation", "LocationID", "dbo.Locations", "LocationID");
        }
    }
}
