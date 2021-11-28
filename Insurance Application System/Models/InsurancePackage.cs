using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Models
{
    public class InsurancePackage
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Availability { get; set; }

        [Required]
        public double Fee { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Asset { get; set; }


        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        public double StandardAdminFee { get; set; }

    }
}