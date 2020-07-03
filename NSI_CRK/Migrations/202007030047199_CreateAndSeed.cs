namespace NSI_CRK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAndSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absence",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 30),
                        TelephoneNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfEmployment = c.DateTime(nullable: false),
                        DateOfContractExpiration = c.DateTime(nullable: false),
                        Position = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Currency = c.String(maxLength: 3),
                        NumberOfEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Absence", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Payment", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "CompanyID", "dbo.Company");
            DropIndex("dbo.Payment", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "CompanyID" });
            DropIndex("dbo.Absence", new[] { "EmployeeID" });
            DropTable("dbo.Payment");
            DropTable("dbo.Company");
            DropTable("dbo.Employee");
            DropTable("dbo.Absence");
        }
    }
}
