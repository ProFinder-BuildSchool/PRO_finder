namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OMG : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.String());
        }
    }
}
