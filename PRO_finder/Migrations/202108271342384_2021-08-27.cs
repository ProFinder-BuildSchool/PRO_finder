namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210827 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Experience");
            //CreateTable(
            //    "dbo.TalentTool",
            //    c => new
            //        {
            //            TalentToolID = c.Int(nullable: false, identity: true),
            //            MemberID = c.Int(nullable: false),
            //            ToolSubCategoryID = c.Int(nullable: false),
            //            ToolSubCategoryName = c.Int(nullable: false),
            //            ToolCategoryID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.TalentToolID);
            
            //AddColumn("dbo.Experience", "ExpID", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.OtherPicture", "OtherPictureLink", c => c.String());
            AlterColumn("dbo.Case", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Quotation", "UpdateDate", c => c.DateTime(nullable: false));
            //AddPrimaryKey("dbo.Experience", "ExpID");
            //DropColumn("dbo.OtherPicture", "OtherPicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OtherPicture", "OtherPicture", c => c.String());
            DropPrimaryKey("dbo.Experience");
            AlterColumn("dbo.Quotation", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Case", "UpdateDate", c => c.DateTime());
            DropColumn("dbo.OtherPicture", "OtherPictureLink");
            DropColumn("dbo.Experience", "ExpID");
            DropTable("dbo.TalentTool");
            AddPrimaryKey("dbo.Experience", "MemberID");
        }
    }
}
