using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Application.Feature.Authentication.UserFeature.Command
{
    public class SignupCommandRequestValidator : AbstractValidator<SignupCommandRequest>
    {
        public SignupCommandRequestValidator() 
        {
            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("Please, use a valid email")
                .NotEmpty().WithMessage("Email is required");

            RuleFor(r => r.Password)
                .MinimumLength(6).WithMessage("Password length must be greater than 5");
        }
    }
}
