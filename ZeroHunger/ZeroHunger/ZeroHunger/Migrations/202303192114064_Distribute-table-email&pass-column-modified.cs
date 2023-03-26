namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Distributetableemailpasscolumnmodified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributes", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Distributes", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Distributes", "Password");
            DropColumn("dbo.Distributes", "Email");
        }
    }
}
