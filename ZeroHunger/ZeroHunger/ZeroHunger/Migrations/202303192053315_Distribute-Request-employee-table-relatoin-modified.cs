namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistributeRequestemployeetablerelatoinmodified : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Distributes", name: "D_Id", newName: "Id");
            RenameIndex(table: "dbo.Distributes", name: "IX_D_Id", newName: "IX_Id");
            AddColumn("dbo.Distributes", "location", c => c.String(nullable: false));
            AddColumn("dbo.Distributes", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Distributes", "OTP", c => c.Int());
            AddColumn("dbo.Distributes", "RecievedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "OTP", c => c.Int());
            DropColumn("dbo.Distributes", "DistributedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributes", "DistributedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Requests", "OTP");
            DropColumn("dbo.Distributes", "RecievedTime");
            DropColumn("dbo.Distributes", "OTP");
            DropColumn("dbo.Distributes", "Name");
            DropColumn("dbo.Distributes", "location");
            RenameIndex(table: "dbo.Distributes", name: "IX_Id", newName: "IX_D_Id");
            RenameColumn(table: "dbo.Distributes", name: "Id", newName: "D_Id");
        }
    }
}
