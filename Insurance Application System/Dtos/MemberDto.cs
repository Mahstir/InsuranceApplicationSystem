﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Dtos
{
    public class MemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}