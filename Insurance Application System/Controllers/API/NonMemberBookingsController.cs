using AutoMapper;
using Insurance_Application_System.Dtos;
using Insurance_Application_System.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance_Application_System.Controllers.API
{
    public class NonMemberBookingsController : ApiController
    {
        private ApplicationDbContext _context;

        public NonMemberBookingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public Booking MyBookings()
        {
            var currentUser = User.Identity.GetUserId();
            var myBookings = _context.Bookings.Include(c => c.InsurancePackage).Include(c => c.Member).SingleOrDefault(c => c.ApplicationUserId == null);

            return myBookings;

        }
    }

}
