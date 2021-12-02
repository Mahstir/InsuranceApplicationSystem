using Insurance_Application_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Insurance_Application_System.Controllers.API
{
    public class InsurancePackagesController : ApiController, IInsurancePackagesController
    {
        private ApplicationDbContext _context;

        public InsurancePackagesController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<InsurancePackage> GetInsurancePackages()
        {
            return _context.InsurancePackages.Include(c => c.MembershipType).ToList();
        }


        public InsurancePackage GetInsurancePackage(int id)
        {
            var package = _context.InsurancePackages.SingleOrDefault(c => c.Id == id);

            if (package == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return package;
        }

        [HttpPost]
        public IHttpActionResult CreateInsurancePackage(InsurancePackage insurancePackage)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.InsurancePackages.Add(insurancePackage);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + insurancePackage.Id), insurancePackage);
        }

        [HttpPut]
        public void UpdateInsurancePackage(int id, InsurancePackage insurancePackage)
        {
          
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var packageInDb = _context.InsurancePackages.SingleOrDefault(c => c.Id == id);

            if (packageInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            packageInDb.Name = insurancePackage.Name;
            packageInDb.Fee = insurancePackage.Fee;
            packageInDb.Asset = insurancePackage.Asset;
            packageInDb.Availability = insurancePackage.Availability;
            packageInDb.Duration = insurancePackage.Duration;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteInsurancePackage(int id)
        {
            var packageInDb = _context.InsurancePackages.SingleOrDefault(c => c.Id == id);

            if (packageInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.InsurancePackages.Remove(packageInDb);
            _context.SaveChanges();

        }

    }

    public interface IInsurancePackagesController
    {
        InsurancePackage GetInsurancePackage(int id);

        void DeleteInsurancePackage(int id);

        void UpdateInsurancePackage(int id, InsurancePackage insurancePackage);

        IHttpActionResult CreateInsurancePackage(InsurancePackage insurancePackage);

        IEnumerable<InsurancePackage> GetInsurancePackages();
    }
}