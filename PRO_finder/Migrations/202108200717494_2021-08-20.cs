namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210820 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CaseNotification", "CaseID", "dbo.Case");
            DropForeignKey("dbo.CaseNotification", "InvitedTalentID", "dbo.Case");
            DropForeignKey("dbo.CaseReference", "CaseID", "dbo.Case");
            DropForeignKey("dbo.HostingDetail", "CaseID", "dbo.Case");
            DropForeignKey("dbo.ProposalRecord", "CaseID", "dbo.Case");
            DropForeignKey("dbo.QuotationDetail", "CaseID", "dbo.Case");
            DropForeignKey("dbo.SaveCase", "CaseID", "dbo.Case");
            DropIndex("dbo.CaseNotification", new[] { "InvitedTalentID" });
            DropIndex("dbo.CaseNotification", new[] { "CaseID" });
            DropIndex("dbo.CaseReference", new[] { "CaseID" });
            DropIndex("dbo.HostingDetail", new[] { "CaseID" });
            DropIndex("dbo.ProposalRecord", new[] { "CaseID" });
            DropIndex("dbo.QuotationDetail", new[] { "CaseID" });
            DropIndex("dbo.SaveCase", new[] { "CaseID" });
            //AddColumn("dbo.MemberInfo", "SubCategoryID", c => c.Int());
            //AddColumn("dbo.Works", "MemberID", c => c.Int());
            AlterColumn("dbo.Case", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.MemberInfo", "Description", c => c.String());
            CreateIndex("dbo.Works", "WorkID");
            AddForeignKey("dbo.Works", "WorkID", "dbo.MemberInfo", "MemberID");
            //DropColumn("dbo.MemberInfo", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberInfo", "CategoryID", c => c.Int());
            DropForeignKey("dbo.Works", "WorkID", "dbo.MemberInfo");
            DropIndex("dbo.Works", new[] { "WorkID" });
            AlterColumn("dbo.MemberInfo", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.Case", "UpdateDate", c => c.Time(precision: 7));
            DropColumn("dbo.Works", "MemberID");
            DropColumn("dbo.MemberInfo", "SubCategoryID");
            CreateIndex("dbo.SaveCase", "CaseID");
            CreateIndex("dbo.QuotationDetail", "CaseID");
            CreateIndex("dbo.ProposalRecord", "CaseID");
            CreateIndex("dbo.HostingDetail", "CaseID");
            CreateIndex("dbo.CaseReference", "CaseID");
            CreateIndex("dbo.CaseNotification", "CaseID");
            CreateIndex("dbo.CaseNotification", "InvitedTalentID");
            AddForeignKey("dbo.SaveCase", "CaseID", "dbo.Case", "CaseID");
            AddForeignKey("dbo.QuotationDetail", "CaseID", "dbo.Case", "CaseID");
            AddForeignKey("dbo.ProposalRecord", "CaseID", "dbo.Case", "CaseID");
            AddForeignKey("dbo.HostingDetail", "CaseID", "dbo.Case", "CaseID");
            AddForeignKey("dbo.CaseReference", "CaseID", "dbo.Case", "CaseID");
            AddForeignKey("dbo.CaseNotification", "InvitedTalentID", "dbo.Case", "CaseID");
            AddForeignKey("dbo.CaseNotification", "CaseID", "dbo.Case", "CaseID");
        }
    }
}
