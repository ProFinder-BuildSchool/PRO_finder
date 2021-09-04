namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210904 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Order", "DealedTalentMemberID", "dbo.MemberInfo");
            //DropIndex("dbo.Order", new[] { "DealedTalentMemberID" });
            //AddColumn("dbo.Order", "ProposerID", c => c.Int());
            //AddColumn("dbo.Order", "ClientID", c => c.Int());
            //AddColumn("dbo.Order", "QuotationImg", c => c.String());
            //AddColumn("dbo.Order", "StudioName", c => c.String(maxLength: 50));
            //AddColumn("dbo.Order", "Count", c => c.Int());
            //AddColumn("dbo.Order", "Unit", c => c.Int());
            //AddColumn("dbo.Order", "Email", c => c.String());
            //AddColumn("dbo.Order", "Name", c => c.String(maxLength: 50));
            //AddColumn("dbo.Order", "Tel", c => c.String(maxLength: 50));
            //AddColumn("dbo.Order", "LineID", c => c.String(maxLength: 50));
            //AddColumn("dbo.Order", "Memo", c => c.String());
            //AddColumn("dbo.Order", "ContactTime", c => c.Int());
            //AddColumn("dbo.Order", "PredictDays", c => c.Int());
            //AddColumn("dbo.QuotationDetail", "Unit", c => c.Int());
            //AddColumn("dbo.ClientCart", "ClientID", c => c.Int());
            //AddColumn("dbo.ClientCart", "ProposerID", c => c.Int());
            //AddColumn("dbo.ClientCart", "PredictDays", c => c.Int());
            //AlterColumn("dbo.Order", "OrderType", c => c.Int());
            //AlterColumn("dbo.Order", "CaseReview", c => c.Decimal(precision: 3, scale: 1));
            //AlterColumn("dbo.Order", "OrderStatus", c => c.Int());
            //AlterColumn("dbo.Order", "DepositStatus", c => c.Int());
            //AlterColumn("dbo.Order", "Price", c => c.Decimal(precision: 18, scale: 0));
            //AlterColumn("dbo.Order", "DealedDate", c => c.DateTime(storeType: "date"));
            //DropColumn("dbo.Order", "SourceID");
            //DropColumn("dbo.Order", "SubmitDate");
            //DropColumn("dbo.Order", "DealedTalentMemberID");
            //DropColumn("dbo.ClientCart", "MemberID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientCart", "MemberID", c => c.Int());
            AddColumn("dbo.Order", "DealedTalentMemberID", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "SubmitDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Order", "SourceID", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "DealedDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Order", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Order", "DepositStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "OrderStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "CaseReview", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            AlterColumn("dbo.Order", "OrderType", c => c.Int(nullable: false));
            DropColumn("dbo.ClientCart", "PredictDays");
            DropColumn("dbo.ClientCart", "ProposerID");
            DropColumn("dbo.ClientCart", "ClientID");
            DropColumn("dbo.QuotationDetail", "Unit");
            DropColumn("dbo.Order", "PredictDays");
            DropColumn("dbo.Order", "ContactTime");
            DropColumn("dbo.Order", "Memo");
            DropColumn("dbo.Order", "LineID");
            DropColumn("dbo.Order", "Tel");
            DropColumn("dbo.Order", "Name");
            DropColumn("dbo.Order", "Email");
            DropColumn("dbo.Order", "Unit");
            DropColumn("dbo.Order", "Count");
            DropColumn("dbo.Order", "StudioName");
            DropColumn("dbo.Order", "QuotationImg");
            DropColumn("dbo.Order", "ClientID");
            DropColumn("dbo.Order", "ProposerID");
            CreateIndex("dbo.Order", "DealedTalentMemberID");
            AddForeignKey("dbo.Order", "DealedTalentMemberID", "dbo.MemberInfo", "MemberID");
        }
    }
}
