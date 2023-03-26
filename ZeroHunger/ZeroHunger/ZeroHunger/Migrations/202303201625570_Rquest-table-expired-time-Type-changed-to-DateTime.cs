namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RquesttableexpiredtimeTypechangedtoDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "ExpiredTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "ExpiredTime", c => c.Int(nullable: false));
        }
    }
}
