namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Case", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.Experience", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.HostingDetail", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.Message", "TargetID", "dbo.MemberInfo");
            DropForeignKey("dbo.Message", "SourceID", "dbo.MemberInfo");
            DropForeignKey("dbo.Order", "DealedTalentMemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.ProposalRecord", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.QuotationDetail", "ProposerID", "dbo.MemberInfo");
            DropForeignKey("dbo.ReplyFrequency", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.SaveStaff", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.SaveStaff", "SavedTalentID", "dbo.MemberInfo");
            DropForeignKey("dbo.ServicePlus", "MemberID", "dbo.MemberInfo");
            DropPrimaryKey("dbo.MemberInfo");
            AlterColumn("dbo.MemberInfo", "MemberID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Case", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Experience", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.HostingDetail", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Message", "TargetID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Message", "SourceID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Order", "DealedTalentMemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.ProposalRecord", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.QuotationDetail", "ProposerID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.ReplyFrequency", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.SaveStaff", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.SaveStaff", "SavedTalentID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.ServicePlus", "MemberID", "dbo.MemberInfo", "MemberID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicePlus", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.SaveStaff", "SavedTalentID", "dbo.MemberInfo");
            DropForeignKey("dbo.SaveStaff", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.ReplyFrequency", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.QuotationDetail", "ProposerID", "dbo.MemberInfo");
            DropForeignKey("dbo.ProposalRecord", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.Order", "DealedTalentMemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.Message", "SourceID", "dbo.MemberInfo");
            DropForeignKey("dbo.Message", "TargetID", "dbo.MemberInfo");
            DropForeignKey("dbo.HostingDetail", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.Experience", "MemberID", "dbo.MemberInfo");
            DropForeignKey("dbo.Case", "MemberID", "dbo.MemberInfo");
            DropPrimaryKey("dbo.MemberInfo");
            AlterColumn("dbo.MemberInfo", "MemberID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.ServicePlus", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.SaveStaff", "SavedTalentID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.SaveStaff", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.ReplyFrequency", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.QuotationDetail", "ProposerID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.ProposalRecord", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Order", "DealedTalentMemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Message", "SourceID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Message", "TargetID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.HostingDetail", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Experience", "MemberID", "dbo.MemberInfo", "MemberID");
            AddForeignKey("dbo.Case", "MemberID", "dbo.MemberInfo", "MemberID");
        }
    }
}
