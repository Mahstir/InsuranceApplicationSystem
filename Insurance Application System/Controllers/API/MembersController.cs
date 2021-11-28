using Insurance_Application_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Insurance_Application_System.Dtos;
using AutoMapper;

namespace Insurance_Application_System.Controllers.API
{
    public class MembersController : ApiController
    {

        private ApplicationDbContext _context = new ApplicationDbContext();


        [HttpGet]
        public IEnumerable<MemberDto> GetMembers()
        {
            return _context.Users.ToList().Select(Mapper.Map<ApplicationUser, MemberDto>);
        }
    }
}