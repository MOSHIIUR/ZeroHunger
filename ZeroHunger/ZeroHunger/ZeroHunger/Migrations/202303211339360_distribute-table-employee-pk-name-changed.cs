namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distributetableemployeepknamechanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Distributes");
            AddColumn("dbo.Distributes", "DistributeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Distributes", "DistributeId");
            DropColumn("dbo.Distributes", "DistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributes", "DistId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Distributes");
            DropColumn("dbo.Distributes", "DistributeId");
            AddPrimaryKey("dbo.Distributes", "DistId");
        }
    }
}
