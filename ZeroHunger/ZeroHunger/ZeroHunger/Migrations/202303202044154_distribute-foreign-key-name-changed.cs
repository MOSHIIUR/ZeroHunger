namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distributeforeignkeynamechanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Distributes", name: "Id", newName: "DistributeId");
            RenameIndex(table: "dbo.Distributes", name: "IX_Id", newName: "IX_DistributeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Distributes", name: "IX_DistributeId", newName: "IX_Id");
            RenameColumn(table: "dbo.Distributes", name: "DistributeId", newName: "Id");
        }
    }
}
