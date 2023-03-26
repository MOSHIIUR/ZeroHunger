namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLogintablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogins");
        }
    }
}
