using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance_Application_System.Models
{

    public class BookingFactory //Booking Factory Class
    {
        public int Id { get; set; }
        public  Booking Booking { get; set; }

    }

    public class GetBookingFactory //Implementation of the Booking Factory Class
    {

        public void Book()
        {
            var bookingFactory = new BookingFactory();//instantiating each member of the class and initializing its properties.

          var firstName =  bookingFactory.Booking.Member.FirstName;
            var lastName = bookingFactory.Booking.Member.LastName;
            var package = bookingFactory.Booking.InsurancePackage;
            var status = bookingFactory.Booking.Status;
        }
    }


}