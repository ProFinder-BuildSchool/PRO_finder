namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210926 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.CaseReference", "CaseCase", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CaseReference", "CaseCase");
        }
    }
}
