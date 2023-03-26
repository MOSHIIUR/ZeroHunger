namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertablecolumnmodifiedv20 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "U_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "U_Id");
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "U_Id");
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
