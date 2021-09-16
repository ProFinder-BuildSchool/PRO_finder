namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210909DBupdate : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Order", "QuotationID", c => c.Int());
            //AddColumn("dbo.Order", "CaseID", c => c.Int());
            //AddColumn("dbo.Order", "Title", c => c.String());
            //AddColumn("dbo.Order", "ProposerEmail", c => c.String());
            //AddColumn("dbo.Order", "ProposerPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "ProposerPhone");
            DropColumn("dbo.Order", "ProposerEmail");
            DropColumn("dbo.Order", "Title");
            DropColumn("dbo.Order", "CaseID");
            DropColumn("dbo.Order", "QuotationID");
        }
    }
}
