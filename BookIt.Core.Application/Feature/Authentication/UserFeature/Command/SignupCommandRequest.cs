using BookIt.Core.Application.Feature.Authentication.UserFeature.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Application.Feature.Authentication.UserFeature.Command
{
    public class SignupCommandRequest : IRequest<AuthResponse>
    {
        public required string Email { get; set; }
        public required string Username { get; set; } 
        public required string Password { get; set; }
    }
}
