namespace Insurance_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStandardAdminFEeToInsurancePackage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InsurancePackages", "StandardAdminFee", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InsurancePackages", "StandardAdminFee");
        }
    }
}
