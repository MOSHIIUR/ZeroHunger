namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Distributetablecolumnreduced : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Distributes", "location", c => c.String());
            AlterColumn("dbo.Distributes", "Name", c => c.String());
            DropColumn("dbo.Distributes", "Email");
            DropColumn("dbo.Distributes", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributes", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Distributes", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Distributes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Distributes", "location", c => c.String(nullable: false));
        }
    }
}
