namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablenameingmorespecified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "empId", "dbo.Employees");
            DropForeignKey("dbo.Distributes", "E_Id", "dbo.Employees");
            DropForeignKey("dbo.Requests", "R_Id", "dbo.Restaurents");
            RenameColumn(table: "dbo.Distributes", name: "E_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.Requests", name: "empId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Requests", name: "R_Id", newName: "RestaurentId");
            RenameIndex(table: "dbo.Distributes", name: "IX_E_Id", newName: "IX_EmployeeId");
            RenameIndex(table: "dbo.Requests", name: "IX_R_Id", newName: "IX_RestaurentId");
            RenameIndex(table: "dbo.Requests", name: "IX_empId", newName: "IX_EmployeeId");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Restaurents");
            AddColumn("dbo.Distributes", "RecieverOTP", c => c.Int());
            AddColumn("dbo.Distributes", "ReceiverPlacedTime", c => c.DateTime(nullable: false));
            //AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            RenameColumn(table: "dbo.Employees", name: "E_Id", newName: "EmployeeId");
            AddColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "EmployeeEmail", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "EmployeeStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "RequestPlacedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "RequestExpiredTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "Requeststatus", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "RequestOTP", c => c.Int());
            //AddColumn("dbo.Restaurents", "RestaurentId", c => c.Int(nullable: false, identity: true));
            RenameColumn(table: "dbo.Restaurents", name: "R_Id", newName: "RestaurentId");
            AddColumn("dbo.Restaurents", "RestaurentName", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "RestaurentEmail", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "RestaurentAddress", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "RestaurentPassword", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            AddPrimaryKey("dbo.Restaurents", "RestaurentId");
            AddForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Distributes", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "RestaurentId", "dbo.Restaurents", "RestaurentId", cascadeDelete: true);
            DropColumn("dbo.Distributes", "location");
            DropColumn("dbo.Distributes", "Name");
            DropColumn("dbo.Distributes", "OTP");
            DropColumn("dbo.Distributes", "PlacedTime");
            //DropColumn("dbo.Employees", "E_Id");
            DropColumn("dbo.Employees", "Name");
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Status");
            DropColumn("dbo.Requests", "PlacedTime");
            DropColumn("dbo.Requests", "ExpiredTime");
            DropColumn("dbo.Requests", "status");
            DropColumn("dbo.Requests", "OTP");
            //DropColumn("dbo.Restaurents", "R_Id");
            DropColumn("dbo.Restaurents", "Name");
            DropColumn("dbo.Restaurents", "Email");
            DropColumn("dbo.Restaurents", "Address");
            DropColumn("dbo.Restaurents", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurents", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Restaurents", "R_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Requests", "OTP", c => c.Int());
            AddColumn("dbo.Requests", "status", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "ExpiredTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "PlacedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "E_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Distributes", "PlacedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Distributes", "OTP", c => c.Int());
            AddColumn("dbo.Distributes", "Name", c => c.String());
            AddColumn("dbo.Distributes", "location", c => c.String());
            DropForeignKey("dbo.Requests", "RestaurentId", "dbo.Restaurents");
            DropForeignKey("dbo.Distributes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees");
            DropPrimaryKey("dbo.Restaurents");
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Restaurents", "RestaurentPassword");
            DropColumn("dbo.Restaurents", "RestaurentAddress");
            DropColumn("dbo.Restaurents", "RestaurentEmail");
            DropColumn("dbo.Restaurents", "RestaurentName");
            DropColumn("dbo.Restaurents", "RestaurentId");
            DropColumn("dbo.Requests", "RequestOTP");
            DropColumn("dbo.Requests", "Requeststatus");
            DropColumn("dbo.Requests", "RequestExpiredTime");
            DropColumn("dbo.Requests", "RequestPlacedTime");
            DropColumn("dbo.Employees", "EmployeeStatus");
            DropColumn("dbo.Employees", "EmployeeEmail");
            DropColumn("dbo.Employees", "EmployeeName");
            DropColumn("dbo.Employees", "EmployeeId");
            DropColumn("dbo.Distributes", "ReceiverPlacedTime");
            DropColumn("dbo.Distributes", "RecieverOTP");
            AddPrimaryKey("dbo.Restaurents", "R_Id");
            AddPrimaryKey("dbo.Employees", "E_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_EmployeeId", newName: "IX_empId");
            RenameIndex(table: "dbo.Requests", name: "IX_RestaurentId", newName: "IX_R_Id");
            RenameIndex(table: "dbo.Distributes", name: "IX_EmployeeId", newName: "IX_E_Id");
            RenameColumn(table: "dbo.Requests", name: "RestaurentId", newName: "R_Id");
            RenameColumn(table: "dbo.Requests", name: "EmployeeId", newName: "empId");
            RenameColumn(table: "dbo.Distributes", name: "EmployeeId", newName: "E_Id");
            AddForeignKey("dbo.Requests", "R_Id", "dbo.Restaurents", "R_Id", cascadeDelete: true);
            AddForeignKey("dbo.Distributes", "E_Id", "dbo.Employees", "E_Id", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "empId", "dbo.Employees", "E_Id");
        }
    }
}
