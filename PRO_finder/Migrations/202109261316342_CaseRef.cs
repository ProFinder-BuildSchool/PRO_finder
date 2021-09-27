namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseRef : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.CaseReference");
            //AlterColumn("dbo.CaseReference", "CaseID", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.CaseReference", "CaseID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CaseReference");
            AlterColumn("dbo.CaseReference", "CaseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CaseReference", "CaseID");
        }
    }
}
