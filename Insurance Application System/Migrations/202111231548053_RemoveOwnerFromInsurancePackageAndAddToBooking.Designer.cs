// <auto-generated />
namespace Insurance_Application_System.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class RemoveOwnerFromInsurancePackageAndAddToBooking : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemoveOwnerFromInsurancePackageAndAddToBooking));
        
        string IMigrationMetadata.Id
        {
            get { return "202111231548053_RemoveOwnerFromInsurancePackageAndAddToBooking"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}