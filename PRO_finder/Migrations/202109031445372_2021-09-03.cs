namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210903 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.QuotationDetail", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuotationDetail", "Status");
        }
    }
}
