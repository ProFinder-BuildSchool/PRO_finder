namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210830 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Experience", "CategoryID", c => c.Int(nullable: false));
            //AddColumn("dbo.Quotation", "Status", c => c.Boolean());
            AlterColumn("dbo.Quotation", "Price", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentTool", "ToolSubCategoryName", c => c.Int(nullable: false));
            AlterColumn("dbo.Quotation", "Price", c => c.Decimal(precision: 5, scale: 0));
            DropColumn("dbo.Quotation", "Status");
            DropColumn("dbo.Experience", "CategoryID");
        }
    }
}
