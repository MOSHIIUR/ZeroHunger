namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onemanyRestaurentRequestlinked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "R_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "R_Id");
            AddForeignKey("dbo.Requests", "R_Id", "dbo.Restaurents", "R_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "R_Id", "dbo.Restaurents");
            DropIndex("dbo.Requests", new[] { "R_Id" });
            DropColumn("dbo.Requests", "R_Id");
        }
    }
}
