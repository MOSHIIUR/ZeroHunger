namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeRequesttablerelationimplemented : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Requests", "empId", c => c.Int());
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.Requests", "empId");
            AddForeignKey("dbo.Requests", "empId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "empId", "dbo.Employees");
            DropIndex("dbo.Requests", new[] { "empId" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Requests", "empId");
            AddPrimaryKey("dbo.Employees", "Id");
        }
    }
}
