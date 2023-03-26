namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistributeRequestemployeetablerelatoinestablished : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Distributes");
            AddColumn("dbo.Distributes", "D_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Distributes", "D_Id");
            CreateIndex("dbo.Distributes", "D_Id");
            AddForeignKey("dbo.Distributes", "D_Id", "dbo.Requests", "Id");
            DropColumn("dbo.Distributes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Distributes", "D_Id", "dbo.Requests");
            DropIndex("dbo.Distributes", new[] { "D_Id" });
            DropPrimaryKey("dbo.Distributes");
            DropColumn("dbo.Distributes", "D_Id");
            AddPrimaryKey("dbo.Distributes", "Id");
        }
    }
}
