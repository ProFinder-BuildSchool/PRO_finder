namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210822 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Works", "WorkAttachmentID", "dbo.WorkAttachment");
            //DropPrimaryKey("dbo.Case");
            //DropPrimaryKey("dbo.WorkAttachment");
            //DropPrimaryKey("dbo.WorkPictures");
            //DropPrimaryKey("dbo.OtherPicture");
            //AddColumn("dbo.Quotation", "MainPicture", c => c.String());
            //AddColumn("dbo.WorkAttachment", "WorkID", c => c.Int());
            AlterColumn("dbo.Case", "CaseID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Case", "CompleteDate", c => c.Int());
            AlterColumn("dbo.Case", "AnswerPhone", c => c.Boolean());
            AlterColumn("dbo.MemberInfo", "EditedTime", c => c.DateTime());
            AlterColumn("dbo.MemberInfo", "isDeleted", c => c.Boolean());
            AlterColumn("dbo.MemberInfo", "CreateUser", c => c.DateTime());
            AlterColumn("dbo.MemberInfo", "UpdateUser", c => c.DateTime());
            AlterColumn("dbo.MemberInfo", "Status", c => c.Boolean());
            AlterColumn("dbo.MemberInfo", "IsThirdLogin", c => c.Boolean());
            AlterColumn("dbo.Quotation", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Quotation", "Evaluation", c => c.Decimal(precision: 2, scale: 1));
            AlterColumn("dbo.WorkAttachment", "WorkAttachmentID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.WorkPictures", "WorkPictureID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Order", "CaseReview", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            AlterColumn("dbo.ProposalRecord", "SavedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReplyFrequency", "Degree", c => c.Decimal(precision: 3, scale: 1));
            AlterColumn("dbo.ServicePlus", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ServicePlus", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OtherPicture", "OtherPictureID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OtherPicture", "IsDefault", c => c.Boolean());
            AlterColumn("dbo.SaveCase", "SavedDate", c => c.DateTime(nullable: false));
            //AddPrimaryKey("dbo.Case", "CaseID");
            //AddPrimaryKey("dbo.WorkAttachment", "WorkAttachmentID");
            //AddPrimaryKey("dbo.WorkPictures", "WorkPictureID");
            //AddPrimaryKey("dbo.OtherPicture", "OtherPictureID");
            //AddForeignKey("dbo.Works", "WorkID", "dbo.MemberInfo", "MemberID");
            //AddForeignKey("dbo.Works", "WorkAttachmentID", "dbo.WorkAttachment", "WorkAttachmentID");
            //DropColumn("dbo.Quotation", "OtherPictureID");
            //DropColumn("dbo.OtherPicture", "MainPicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OtherPicture", "MainPicture", c => c.String(nullable: false));
            AddColumn("dbo.Quotation", "OtherPictureID", c => c.Int());
            DropForeignKey("dbo.Works", "WorkAttachmentID", "dbo.WorkAttachment");
            DropForeignKey("dbo.Works", "WorkID", "dbo.MemberInfo");
            DropPrimaryKey("dbo.OtherPicture");
            DropPrimaryKey("dbo.WorkPictures");
            DropPrimaryKey("dbo.WorkAttachment");
            DropPrimaryKey("dbo.Case");
            AlterColumn("dbo.SaveCase", "SavedDate", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.OtherPicture", "IsDefault", c => c.Byte(nullable: false));
            AlterColumn("dbo.OtherPicture", "OtherPictureID", c => c.Int(nullable: false));
            AlterColumn("dbo.ServicePlus", "EndDate", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.ServicePlus", "StartDate", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.ReplyFrequency", "Degree", c => c.Decimal(precision: 3, scale: 0));
            AlterColumn("dbo.ProposalRecord", "SavedDate", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Order", "CaseReview", c => c.Decimal(nullable: false, precision: 3, scale: 0));
            AlterColumn("dbo.WorkPictures", "WorkPictureID", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkAttachment", "WorkAttachmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Quotation", "Evaluation", c => c.Decimal(precision: 2, scale: 0));
            AlterColumn("dbo.Quotation", "UpdateDate", c => c.Time(precision: 7));
            AlterColumn("dbo.MemberInfo", "IsThirdLogin", c => c.Byte());
            AlterColumn("dbo.MemberInfo", "Status", c => c.Byte());
            AlterColumn("dbo.MemberInfo", "UpdateUser", c => c.Time(precision: 7));
            AlterColumn("dbo.MemberInfo", "CreateUser", c => c.Time(precision: 7));
            AlterColumn("dbo.MemberInfo", "isDeleted", c => c.Byte());
            AlterColumn("dbo.MemberInfo", "EditedTime", c => c.Time(precision: 7));
            AlterColumn("dbo.Case", "AnswerPhone", c => c.Byte());
            AlterColumn("dbo.Case", "CompleteDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Case", "CaseID", c => c.Int(nullable: false));
            DropColumn("dbo.WorkAttachment", "WorkID");
            DropColumn("dbo.Quotation", "MainPicture");
            AddPrimaryKey("dbo.OtherPicture", "OtherPictureID");
            AddPrimaryKey("dbo.WorkPictures", "WorkPictureID");
            AddPrimaryKey("dbo.WorkAttachment", "WorkAttachmentID");
            AddPrimaryKey("dbo.Case", "CaseID");
            AddForeignKey("dbo.Works", "WorkAttachmentID", "dbo.WorkAttachment", "WorkAttachmentID");
        }
    }
}
