using Insurance_Application_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance_Application_System.Controllers.API
{
    public class MembershipTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }


        public MembershipType GetMembershipType(int id)
        {
            var membershipType = _context.MembershipTypes.SingleOrDefault(c => c.Id == id);

            if (membershipType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return membershipType;
        }

        [HttpPost]
        public IHttpActionResult CreateMembershipType(MembershipType membershipType)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.MembershipTypes.Add(membershipType);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + membershipType.Id), membershipType);
        }

        [HttpPut]
        public void UpdateMembershipType(int id, MembershipType membershipType)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var membershipTypeInDb = _context.MembershipTypes.SingleOrDefault(c => c.Id == id);

            if (membershipTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            membershipTypeInDb.AnnualFee = membershipType.AnnualFee;
            membershipTypeInDb.Benefit = membershipType.Benefit;
            membershipTypeInDb.DiscountRate = membershipType.DiscountRate;
            membershipTypeInDb.Name = membershipType.Name;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMembershipType(int id)
        {
            var membershipTypeInDb = _context.MembershipTypes.SingleOrDefault(c => c.Id == id);

            if (membershipTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.MembershipTypes.Remove(membershipTypeInDb);
            _context.SaveChanges();

        }

    }
}