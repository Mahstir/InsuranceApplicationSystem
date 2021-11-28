using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insurance_Application_System.Models;
using Insurance_Application_System.Dtos;


namespace Insurance_Application_System.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, MemberDto>();
            Mapper.CreateMap<MemberDto, ApplicationUser>();
        }
    }
}