namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistributeTableAddedRelationlinked : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Distributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistributedAt = c.DateTime(nullable: false),
                        E_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.E_Id, cascadeDelete: true)
                .Index(t => t.E_Id);
            
            AddColumn("dbo.Requests", "D_Id", c => c.Int());
            CreateIndex("dbo.Requests", "D_Id");
            AddForeignKey("dbo.Requests", "D_Id", "dbo.Distributes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Distributes", "E_Id", "dbo.Employees");
            DropForeignKey("dbo.Requests", "D_Id", "dbo.Distributes");
            DropIndex("dbo.Requests", new[] { "D_Id" });
            DropIndex("dbo.Distributes", new[] { "E_Id" });
            DropColumn("dbo.Requests", "D_Id");
            DropTable("dbo.Distributes");
        }
    }
}
