using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Models.ViewModel
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public IEnumerable<InsurancePackage> InsurancePackages { get; set; }

        public InsurancePackage InsurancePackage { get; set; }
        public NonMember NonMember { get; set; }

        public int? InsurancePackageId { get; set; }

        public double StandardAdminFee { get; set; }
    }
}