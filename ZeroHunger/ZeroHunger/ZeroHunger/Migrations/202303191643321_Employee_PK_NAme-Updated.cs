namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_PK_NAmeUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "empId", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Employees", "E_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "E_Id");
            AddForeignKey("dbo.Requests", "empId", "dbo.Employees", "E_Id");
            DropColumn("dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Requests", "empId", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "E_Id");
            AddPrimaryKey("dbo.Employees", "Id");
            AddForeignKey("dbo.Requests", "empId", "dbo.Employees", "Id");
        }
    }
}
