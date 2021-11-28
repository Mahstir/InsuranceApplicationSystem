using Insurance_Application_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurance_Application_System.Controllers.API
{
    public class NonMembersController : ApiController
    {
        private ApplicationDbContext _context;

        public NonMembersController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<NonMember> GetNonMembers()
        {
            return _context.NonMembers.ToList();
        }


        public NonMember GetNonMember(int id)
        {
            var nonMember = _context.NonMembers.SingleOrDefault(c => c.Id == id);

            if (nonMember == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return nonMember;
        }

        [HttpPost]
        public IHttpActionResult CreateNonmember(NonMember nonMember)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.NonMembers.Add(nonMember);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + nonMember.Id), nonMember);
        }

        [HttpPut]
        public void UpdateNonMember(int id, NonMember nonMember)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var nonMemberInDb = _context.NonMembers.SingleOrDefault(c => c.Id == id);

            if (nonMemberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            nonMemberInDb.EmailAddress = nonMember.EmailAddress;
            nonMemberInDb.FirstName = nonMember.FirstName;
            nonMemberInDb.InsurancePackageId = nonMember.InsurancePackageId;
            nonMemberInDb.LastName = nonMember.LastName;
            nonMemberInDb.StandardAdminFee = nonMember.StandardAdminFee;
            nonMemberInDb.PhoneNumber = nonMember.PhoneNumber;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeletenonMember(int id)
        {
            var nonMemberInDb = _context.NonMembers.SingleOrDefault(c => c.Id == id);

            if (nonMemberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.NonMembers.Remove(nonMemberInDb);
            _context.SaveChanges();

        }

    }
}
