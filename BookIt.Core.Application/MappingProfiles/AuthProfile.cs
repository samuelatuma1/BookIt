using AutoMapper;
using BookIt.Core.Application.Feature.Authentication.UserFeature.Command;
using BookIt.Core.Domain.Authentication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Application.MappingProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<SignupCommandRequest, User>().ReverseMap();
        }

    }
}
