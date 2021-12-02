using Insurance_Application_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance_Application_System.Controllers
{
    public class InsurancePackageController : Controller
    {
        // GET: InsurancePackage

        private ApplicationDbContext _context;

        public InsurancePackageController()
        {
            _context = new ApplicationDbContext();
        }

     public ActionResult Index()
        {
            return View();
        }

    }

    public interface IInsurancePackageController
    {
        ActionResult Index();


    }
}