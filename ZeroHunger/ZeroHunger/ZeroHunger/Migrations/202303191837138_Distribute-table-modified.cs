namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Distributetablemodified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "D_Id", "dbo.Distributes");
            DropIndex("dbo.Requests", new[] { "D_Id" });
            DropColumn("dbo.Requests", "D_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "D_Id", c => c.Int());
            CreateIndex("dbo.Requests", "D_Id");
            AddForeignKey("dbo.Requests", "D_Id", "dbo.Distributes", "Id");
        }
    }
}
