namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Distributetablenewlycreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Distributes", "U_Id", "dbo.Users");
            DropForeignKey("dbo.Distributes", "DistId", "dbo.Requests");
            DropIndex("dbo.Distributes", new[] { "DistId" });
            DropIndex("dbo.Distributes", new[] { "U_Id" });
            AddColumn("dbo.Distributes", "CollectedTime", c => c.DateTime());
            AddColumn("dbo.Distributes", "CompletedTime", c => c.DateTime());
            AddColumn("dbo.Distributes", "RequestId", c => c.Int(nullable: false));
            AddColumn("dbo.Distributes", "ReceiveId", c => c.Int(nullable: false));
            AlterColumn("dbo.Distributes", "DistId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Distributes", "DistId");
            CreateIndex("dbo.Distributes", "RequestId");
            CreateIndex("dbo.Distributes", "ReceiveId");
            AddForeignKey("dbo.Distributes", "ReceiveId", "dbo.Receives", "ReceiveRequestId", cascadeDelete: true);
            AddForeignKey("dbo.Distributes", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
            //DropColumn("dbo.Distributes", "RecieverOTP");
            ////DropColumn("dbo.Distributes", "ReceiverPlacedTime");
            //DropColumn("dbo.Distributes", "RecievedTime");
            //DropColumn("dbo.Distributes", "U_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributes", "U_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Distributes", "RecievedTime", c => c.DateTime());
            AddColumn("dbo.Distributes", "ReceiverPlacedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Distributes", "RecieverOTP", c => c.Int());
            DropForeignKey("dbo.Distributes", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Distributes", "ReceiveId", "dbo.Receives");
            DropIndex("dbo.Distributes", new[] { "ReceiveId" });
            DropIndex("dbo.Distributes", new[] { "RequestId" });
            DropPrimaryKey("dbo.Distributes");
            AlterColumn("dbo.Distributes", "DistId", c => c.Int(nullable: false));
            DropColumn("dbo.Distributes", "ReceiveId");
            DropColumn("dbo.Distributes", "RequestId");
            DropColumn("dbo.Distributes", "CompletedTime");
            DropColumn("dbo.Distributes", "CollectedTime");
            AddPrimaryKey("dbo.Distributes", "DistId");
            CreateIndex("dbo.Distributes", "U_Id");
            CreateIndex("dbo.Distributes", "DistId");
            AddForeignKey("dbo.Distributes", "DistId", "dbo.Requests", "Id");
            AddForeignKey("dbo.Distributes", "U_Id", "dbo.Users", "U_Id", cascadeDelete: true);
        }
    }
}
