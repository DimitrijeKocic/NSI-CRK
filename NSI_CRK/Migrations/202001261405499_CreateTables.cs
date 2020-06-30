namespace NSI_CRK.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Employee",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    City = c.String(),
                    Address = c.String(),
                    TelephoneNumber = c.String(),
                    DateOfBirth = c.DateTime(nullable: false),
                    DateOfEmployment = c.DateTime(nullable: false),
                    DateOfContractExpiration = c.DateTime(nullable: false),
                    Position = c.Int(nullable: false),
                    Salary = c.Double(nullable: false),
                    Company_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.Company_ID)
                .Index(t => t.Company_ID);

            CreateTable(
                "dbo.Absence",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "Employee_ID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Company_ID", "dbo.Company");
            DropForeignKey("dbo.Absence", "Employee_ID", "dbo.Employee");
            DropIndex("dbo.Payment", new[] { "Employee_ID" });
            DropIndex("dbo.Employee", new[] { "Company_ID" });
            DropIndex("dbo.Absence", new[] { "Employee_ID" });
            DropTable("dbo.Payment");
            DropTable("dbo.Company");
            DropTable("dbo.Employee");
            DropTable("dbo.Absence");
        }
    }
}
