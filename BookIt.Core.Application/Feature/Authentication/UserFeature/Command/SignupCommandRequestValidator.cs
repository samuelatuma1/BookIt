using BookIt.Core.Application.Contracts.Persistence.Authentication;
using BookIt.Core.Application.Exceptions;
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
        private readonly IUserRepository _userRepository;
        public SignupCommandRequestValidator(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("Please, use a valid email")
                .NotEmpty().WithMessage("Email is required");

            RuleFor(r => r.Password)
                .MinimumLength(6).WithMessage("Password length must be greater than 5");

            RuleFor(r => r.Email).MustAsync(CheckUniqueEmailAsync).WithMessage("Email already exists");
        }

        public async Task<bool> CheckUniqueEmailAsync(string email, CancellationToken token)
        {
            return  !(await _userRepository.CheckUniqueEmailAsync(email));
            
        }
    }
}
