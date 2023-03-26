namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userdistributerelationestablished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributes", "U_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Distributes", "U_Id");
            AddForeignKey("dbo.Distributes", "U_Id", "dbo.Users", "U_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Distributes", "U_Id", "dbo.Users");
            DropIndex("dbo.Distributes", new[] { "U_Id" });
            DropColumn("dbo.Distributes", "U_Id");
        }
    }
}
