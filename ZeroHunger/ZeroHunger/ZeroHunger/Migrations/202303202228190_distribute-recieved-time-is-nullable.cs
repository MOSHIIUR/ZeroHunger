namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distributerecievedtimeisnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Distributes", "RecievedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Distributes", "RecievedTime", c => c.DateTime(nullable: false));
        }
    }
}
