namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableprimarykeychanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserLogins");
            AddColumn("dbo.UserLogins", "UserID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserLogins", "Email", c => c.String());
            AddPrimaryKey("dbo.UserLogins", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserLogins");
            AlterColumn("dbo.UserLogins", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserLogins", "UserID");
            AddPrimaryKey("dbo.UserLogins", "Email");
        }
    }
}
