namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210830購物車data : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.QuotationDetail");
            //CreateTable(
            //    "dbo.ClientCart",
            //    c => new
            //        {
            //            CartID = c.Int(nullable: false, identity: true),
            //            MemberID = c.Int(),
            //            QuotationImg = c.String(),
            //            SubCategoryName = c.String(),
            //            StudioName = c.String(maxLength: 50),
            //            Count = c.Int(),
            //            Price = c.Decimal(precision: 18, scale: 0),
            //            Unit = c.Int(),
            //        })
            //    .PrimaryKey(t => t.CartID);
            
            //CreateTable(
            //    "dbo.OrdersInformation",
            //    c => new
            //        {
            //            OrderInfoID = c.Int(nullable: false, identity: true),
            //            CartID = c.Int(),
            //            Email = c.String(),
            //            Name = c.String(maxLength: 50),
            //            Tel = c.String(maxLength: 50),
            //            LineID = c.String(maxLength: 50),
            //            Memo = c.String(),
            //            ContactTime = c.Int(),
            //        })
            //    .PrimaryKey(t => t.OrderInfoID);
            
            //AddColumn("dbo.QuotationDetail", "QuotaionDetailID", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.QuotationDetail", "ProposeDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.QuotationDetail", "ProposePrice", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            //AddPrimaryKey("dbo.QuotationDetail", "QuotaionDetailID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.QuotationDetail");
            DropColumn("dbo.QuotationDetail", "ProposePrice");
            DropColumn("dbo.QuotationDetail", "ProposeDate");
            DropColumn("dbo.QuotationDetail", "QuotaionDetailID");
            DropTable("dbo.OrdersInformation");
            DropTable("dbo.ClientCart");
            AddPrimaryKey("dbo.QuotationDetail", "ProposerID");
        }
    }
}
