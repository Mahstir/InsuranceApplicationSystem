namespace Insurance_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstSetOfModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        InsurancePackageId = c.Int(nullable: false),
                        Status = c.String(),
                        Payout = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InsurancePackages", t => t.InsurancePackageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.InsurancePackageId);
            
            CreateTable(
                "dbo.InsurancePackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Availability = c.Int(nullable: false),
                        Fee = c.Double(nullable: false),
                        Duration = c.Int(nullable: false),
                        Asset = c.String(nullable: false),
                        Owner = c.String(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AnnualFee = c.Double(nullable: false),
                        DiscountRate = c.Double(nullable: false),
                        Benefit = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NonMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        StandardAdminFee = c.Double(nullable: false),
                        InsurancePackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InsurancePackages", t => t.InsurancePackageId, cascadeDelete: true)
                .Index(t => t.InsurancePackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NonMembers", "InsurancePackageId", "dbo.InsurancePackages");
            DropForeignKey("dbo.Bookings", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "InsurancePackageId", "dbo.InsurancePackages");
            DropForeignKey("dbo.InsurancePackages", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.NonMembers", new[] { "InsurancePackageId" });
            DropIndex("dbo.InsurancePackages", new[] { "MembershipTypeId" });
            DropIndex("dbo.Bookings", new[] { "InsurancePackageId" });
            DropIndex("dbo.Bookings", new[] { "ApplicationUserId" });
            DropTable("dbo.NonMembers");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.InsurancePackages");
            DropTable("dbo.Bookings");
        }
    }
}
