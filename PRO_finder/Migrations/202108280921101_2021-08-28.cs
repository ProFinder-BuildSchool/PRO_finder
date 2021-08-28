namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210828 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.WorkPictures");
            AlterColumn("dbo.WorkPictures", "WorkPictureID", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.WorkPictures", "WorkPictureID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.WorkPictures");
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.String());
            AlterColumn("dbo.WorkPictures", "WorkPictureID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.WorkPictures", "WorkPictureID");
        }
    }
}
