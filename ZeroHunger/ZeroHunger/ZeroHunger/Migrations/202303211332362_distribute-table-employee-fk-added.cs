namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distributetableemployeefkadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributes", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Distributes", "EmployeeId");
            AddForeignKey("dbo.Distributes", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Distributes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Distributes", new[] { "EmployeeId" });
            DropColumn("dbo.Distributes", "EmployeeId");
        }
    }
}
