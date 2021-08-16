namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210816 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Case", "SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.Case", new[] { "SubCategoryID" });
            DropIndex("dbo.Case", new[] { "MemberID" });
            AlterColumn("dbo.Case", "SortNumber", c => c.Int());
            AlterColumn("dbo.Case", "CaseTitle", c => c.String(maxLength: 30));
            AlterColumn("dbo.Case", "SubCategoryID", c => c.Int());
            AlterColumn("dbo.Case", "UpdateDate", c => c.Time(precision: 7));
            AlterColumn("dbo.Case", "Price", c => c.Int());
            AlterColumn("dbo.Case", "Description", c => c.String());
            AlterColumn("dbo.Case", "MemberID", c => c.Int());
            AlterColumn("dbo.Case", "Type", c => c.Int());
            AlterColumn("dbo.Case", "CaseStatus", c => c.Int());
            AlterColumn("dbo.Case", "Contact", c => c.String(maxLength: 50));
            AlterColumn("dbo.Case", "AnswerPhone", c => c.Byte());
            AlterColumn("dbo.Case", "ContactTime", c => c.String(maxLength: 50));
            AlterColumn("dbo.Case", "ContactEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 50));
            CreateIndex("dbo.Case", "MemberID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Case", new[] { "MemberID" });
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.Case", "ContactEmail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Case", "ContactTime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Case", "AnswerPhone", c => c.Byte(nullable: false));
            AlterColumn("dbo.Case", "Contact", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Case", "CaseStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Case", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Case", "MemberID", c => c.Int(nullable: false));
            AlterColumn("dbo.Case", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Case", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Case", "UpdateDate", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Case", "SubCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Case", "CaseTitle", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Case", "SortNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Case", "MemberID");
            CreateIndex("dbo.Case", "SubCategoryID");
            AddForeignKey("dbo.Case", "SubCategoryID", "dbo.SubCategory", "SubCategoryID");
        }
    }
}
