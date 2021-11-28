using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Models
{
    public class NonMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public double StandardAdminFee { get; set; }
        public InsurancePackage InsurancePackage { get; set; }
        public int InsurancePackageId { get; set; }

    }
}