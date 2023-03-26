namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OTPshiftfromrequestreceivetodistribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributes", "SenderOTP", c => c.Int());
            AddColumn("dbo.Distributes", "ReceiverOTP", c => c.Int());
            DropColumn("dbo.Receives", "RequestOTP");
            DropColumn("dbo.Requests", "RequestOTP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "RequestOTP", c => c.Int());
            AddColumn("dbo.Receives", "RequestOTP", c => c.Int());
            DropColumn("dbo.Distributes", "ReceiverOTP");
            DropColumn("dbo.Distributes", "SenderOTP");
        }
    }
}
