namespace PRO_finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210906DBUpdate : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Order");
            //AddColumn("dbo.MemberInfo", "BankCode", c => c.String(maxLength: 50));
            //AddColumn("dbo.MemberInfo", "BankAccount", c => c.String());
            //AddColumn("dbo.Order", "MemberID", c => c.Int());
            //AlterColumn("dbo.MemberInfo", "ProfilePicture", c => c.String());
            //AlterColumn("dbo.Order", "OrderID", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Order", "OrderID");
            //CreateIndex("dbo.Order", "MemberID");
            //AddForeignKey("dbo.Order", "MemberID", "dbo.MemberInfo", "MemberID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "MemberID", "dbo.MemberInfo");
            DropIndex("dbo.Order", new[] { "MemberID" });
            DropPrimaryKey("dbo.Order");
            AlterColumn("dbo.Order", "OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.MemberInfo", "ProfilePicture", c => c.Binary(storeType: "image"));
            DropColumn("dbo.Order", "MemberID");
            DropColumn("dbo.MemberInfo", "BankAccount");
            DropColumn("dbo.MemberInfo", "BankCode");
            AddPrimaryKey("dbo.Order", "OrderID");
        }
    }
}
