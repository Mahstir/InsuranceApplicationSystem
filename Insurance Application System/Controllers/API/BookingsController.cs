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
    public class BookingsController : ApiController
    {
        private ApplicationDbContext _context;

        public BookingsController()
        {
            _context = new ApplicationDbContext();
        }

        //public IEnumerable<Booking> GetBookings()
        //{

        //    return _context.Bookings.Include(c => c.InsurancePackage).Include(c => c.Member).ToList();

        //}

        public IHttpActionResult NewBooking(Booking booking)
        {
            var member = _context.Users.SingleOrDefault(c => c.Id == booking.Member.Id);
            var package = _context.InsurancePackages.SingleOrDefault(c => c.Id == booking.InsurancePackage.Id);

            member = booking.Member;
            package = booking.InsurancePackage;

            _context.Bookings.Add(booking);

            _context.SaveChanges();
            return Ok();
        }

   
    }
}