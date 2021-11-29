using Insurance_Application_System.Models;
using Insurance_Application_System.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Insurance_Application_System.Controllers.API
{
    public class BookingController : Controller
    {

        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;

        public BookingController()
        {
            _context = new ApplicationDbContext();
            System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
        public BookingController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
           
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
     
        // GET: Booking
        
        [Authorize(Roles = "Financial Advisor")]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult BookingForm(int? id)
        {
            var insuranceId = _context.InsurancePackages.SingleOrDefault(c => c.Id == id).Id;
            var insurancePackageName = _context.InsurancePackages.SingleOrDefault(c => c.Id == id).Name;
            var insurancePackageAdminFee = _context.InsurancePackages.SingleOrDefault(c => c.Id == id).StandardAdminFee;

            var viewModel = new BookingViewModel
            {
                InsurancePackageId = insuranceId,
                StandardAdminFee = insurancePackageAdminFee,

            };



            ViewBag.Id = insuranceId;
            ViewBag.Test = insurancePackageName;

            if (User.Identity.IsAuthenticated)
                return View("AuthenticatedUserBooking", viewModel);

            return View(viewModel);
        }

        public ActionResult Save(Booking booking)
        {
            var book = _context.Bookings.Include(c => c.InsurancePackage).Include(c => c.Member).SingleOrDefault(c => c.Id == booking.Id);
            var package = _context.InsurancePackages.SingleOrDefault(c => c.Id == booking.InsurancePackageId);

            var userId = TempData["Newmessage"] as string;

          
            booking.ApplicationUserId = userId;

         

            if (booking.Id == 0 ) 
            {
                booking.Status = "Active";

             
                _context.Bookings.Add(booking);
                package.Availability--;
            }
            else
            {
                var trainingInDb = _context.Bookings.Single(m => m.Id == booking.Id);
                TryUpdateModel(trainingInDb);
            }

            _context.SaveChanges();

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("OneBooking");

            return RedirectToAction("Index", "InsurancePackage");
        }

        public ActionResult MyBooking()
        {
            return View();
        }

        public ActionResult OneBooking()
        {
            var currentUser = User.Identity.GetUserId();
            var myBookings = _context.Bookings.Include(c => c.InsurancePackage).Include(c => c.Member).Where(c => c.ApplicationUserId == currentUser).ToList();

            return View(myBookings);

        }

        public ActionResult Edit(int id)
        {
            var bookingInDb = _context.Bookings.Include(c => c.Member).Include(c => c.InsurancePackage).SingleOrDefault(c => c.Id == id);

            var viewModel = new BookingViewModel()
            {
                Booking = bookingInDb,
                InsurancePackages = bookingInDb.InsurancePackages
            };

            return View(viewModel);
        }

        public ActionResult AllBookings()
        {

            var allBookings = _context.Bookings.Include(c => c.InsurancePackage).Include(c => c.Member).ToList();

            return View(allBookings);

        }
    }
}