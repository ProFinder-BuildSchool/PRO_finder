namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210908DBupdate : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Order", "CompleteDate", c => c.DateTime());
            //AddColumn("dbo.Order", "PaymentCode", c => c.String(maxLength: 50));
            //AddColumn("dbo.ClientCart", "QuotationID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientCart", "QuotationID");
            DropColumn("dbo.Order", "PaymentCode");
            DropColumn("dbo.Order", "CompleteDate");
        }
    }
}
