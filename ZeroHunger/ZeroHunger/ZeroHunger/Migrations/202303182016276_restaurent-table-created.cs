namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurenttablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurents",
                c => new
                    {
                        R_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.R_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurents");
        }
    }
}
