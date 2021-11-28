using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Models
{
    public class MembershipType
    {
  
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double AnnualFee { get; set; }

        [Required]
        public double DiscountRate { get; set; }

        [Required]
        public string Benefit { get; set; }

    }
}