namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistributetablerequestTimecolumnadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributes", "PlacedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Distributes", "PlacedTime");
        }
    }
}
