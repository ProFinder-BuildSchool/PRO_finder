namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210901 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Works", "WorkID", "dbo.MemberInfo");
            //DropIndex("dbo.Works", new[] { "WorkID" });
            //DropPrimaryKey("dbo.SaveStaff");
            //DropPrimaryKey("dbo.SaveCase");
            //AddColumn("dbo.ClientCart", "Email", c => c.String());
            //AddColumn("dbo.ClientCart", "Name", c => c.String(maxLength: 50));
            //AddColumn("dbo.ClientCart", "Tel", c => c.String(maxLength: 50));
            //AddColumn("dbo.ClientCart", "LineID", c => c.String(maxLength: 50));
            //AddColumn("dbo.ClientCart", "Memo", c => c.String());
            //AddColumn("dbo.ClientCart", "ContactTime", c => c.Int());
            //AddColumn("dbo.SaveCase", "SaveCaseID", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.SaveStaff", "SaveStaffID", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.SaveCase", "CaseID", c => c.Int());
            //AddPrimaryKey("dbo.SaveStaff", "SaveStaffID");
            //AddPrimaryKey("dbo.SaveCase", "SaveCaseID");
            //DropTable("dbo.OrdersInformation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrdersInformation",
                c => new
                    {
                        OrderInfoID = c.Int(nullable: false, identity: true),
                        CartID = c.Int(),
                        Email = c.String(),
                        Name = c.String(maxLength: 50),
                        Tel = c.String(maxLength: 50),
                        LineID = c.String(maxLength: 50),
                        Memo = c.String(),
                        ContactTime = c.Int(),
                    })
                .PrimaryKey(t => t.OrderInfoID);
            
            DropPrimaryKey("dbo.SaveCase");
            DropPrimaryKey("dbo.SaveStaff");
            AlterColumn("dbo.SaveCase", "CaseID", c => c.Int(nullable: false));
            AlterColumn("dbo.SaveStaff", "SaveStaffID", c => c.Int(nullable: false));
            DropColumn("dbo.SaveCase", "SaveCaseID");
            DropColumn("dbo.ClientCart", "ContactTime");
            DropColumn("dbo.ClientCart", "Memo");
            DropColumn("dbo.ClientCart", "LineID");
            DropColumn("dbo.ClientCart", "Tel");
            DropColumn("dbo.ClientCart", "Name");
            DropColumn("dbo.ClientCart", "Email");
            AddPrimaryKey("dbo.SaveCase", "CaseID");
            AddPrimaryKey("dbo.SaveStaff", "SaveStaffID");
            CreateIndex("dbo.Works", "WorkID");
            AddForeignKey("dbo.Works", "WorkID", "dbo.MemberInfo", "MemberID");
        }
    }
}
