﻿namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requesttablesimplified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Requests", new[] { "EmployeeId" });
            DropColumn("dbo.Requests", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Requests", "EmployeeId");
            AddForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
