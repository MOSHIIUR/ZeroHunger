namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodReceiveRequestTablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receives",
                c => new
                    {
                        ReceiveRequestId = c.Int(nullable: false, identity: true),
                        PlacedTime = c.DateTime(nullable: false),
                        Requeststatus = c.Int(nullable: false),
                        RequestOTP = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiveRequestId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receives", "UserId", "dbo.Users");
            DropIndex("dbo.Receives", new[] { "UserId" });
            DropTable("dbo.Receives");
        }
    }
}
