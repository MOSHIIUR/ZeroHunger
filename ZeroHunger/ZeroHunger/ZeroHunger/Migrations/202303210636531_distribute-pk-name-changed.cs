namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distributepknamechanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Distributes", name: "DistributeId", newName: "DistId");
            RenameIndex(table: "dbo.Distributes", name: "IX_DistributeId", newName: "IX_DistId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Distributes", name: "IX_DistId", newName: "IX_DistributeId");
            RenameColumn(table: "dbo.Distributes", name: "DistId", newName: "DistributeId");
        }
    }
}
