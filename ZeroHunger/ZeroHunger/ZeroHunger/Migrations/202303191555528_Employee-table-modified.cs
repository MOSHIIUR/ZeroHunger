namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employeetablemodified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Phone");
            DropColumn("dbo.Employees", "Staus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Staus", c => c.String());
            AddColumn("dbo.Employees", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Role", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Status");
        }
    }
}
