using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public ApplicationUser Member { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<InsurancePackage> InsurancePackages { get; set; }
        public InsurancePackage InsurancePackage { get; set; }

        public int InsurancePackageId { get; set; }
        public string Status { get; set; }
        public bool Payout { get; set; }

        public string Owner { get; set; }
    }
}