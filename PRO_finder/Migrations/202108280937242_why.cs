namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class why : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.Int(nullable: false));
        }
    }
}
