namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210928 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.CaseReference");
            //AddColumn("dbo.BackAccount", "Deactivated", c => c.Int());
            //AddColumn("dbo.CaseReference", "CaseRefID", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.CaseReference", "CaseRef", c => c.String());
            //AlterColumn("dbo.CaseReference", "CaseID", c => c.Int());
            //AddPrimaryKey("dbo.CaseReference", "CaseRefID");
            //DropColumn("dbo.CaseReference", "CaseRefImg");
            //DropColumn("dbo.CaseReference", "CaseCase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CaseReference", "CaseCase", c => c.Int(nullable: false));
            AddColumn("dbo.CaseReference", "CaseRefImg", c => c.String());
            DropPrimaryKey("dbo.CaseReference");
            AlterColumn("dbo.CaseReference", "CaseID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.CaseReference", "CaseRef");
            DropColumn("dbo.CaseReference", "CaseRefID");
            DropColumn("dbo.BackAccount", "Deactivated");
            AddPrimaryKey("dbo.CaseReference", "CaseID");
        }
    }
}
