namespace Insurance_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOwnerFromInsurancePackageAndAddToBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Owner", c => c.String());
            DropColumn("dbo.InsurancePackages", "Owner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InsurancePackages", "Owner", c => c.String(nullable: false));
            DropColumn("dbo.Bookings", "Owner");
        }
    }
}
