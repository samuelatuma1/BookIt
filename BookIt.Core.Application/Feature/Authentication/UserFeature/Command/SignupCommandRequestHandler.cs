using AutoMapper;
using BookIt.Core.Application.Config;
using BookIt.Core.Application.Contracts.AuthService;
using BookIt.Core.Application.Contracts.Persistence.Authentication;
using BookIt.Core.Application.Exceptions;
using BookIt.Core.Application.Feature.Authentication.UserFeature.Common.Dto;
using BookIt.Core.Application.Feature.Authentication.UserFeature.Common.Services;
using BookIt.Core.Application.Utilities;
using BookIt.Core.Domain.Authentication.Entity;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Application.Feature.Authentication.UserFeature.Command
{
    public class SignupCommandRequestHandler : IRequestHandler<SignupCommandRequest, AuthResponse>
    {
        private readonly IMapper _mapper;
        private readonly HashConfig _hashConfig;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public SignupCommandRequestHandler(IMapper mapper, IOptions<HashConfig> hashConfig, IUserRepository userRepository, IJwtService jwtService)
        {
            _mapper = mapper;
            _hashConfig = hashConfig.Value;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        public async Task<AuthResponse> Handle(SignupCommandRequest request, CancellationToken cancellationToken)
        {
            var signupRequestValidator = new SignupCommandRequestValidator(_userRepository);
            var validations = await signupRequestValidator.ValidateAsync(request, cancellationToken);

            if (validations.Errors.Any())
            {
               IDictionary<string, string> errors = validations.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);
                throw new BadRequestException("Invalid input types", errors);
            }

            // Convert from SignupCommandRequest to Entity
            var user = _mapper.Map<User>(request);

            // Hash Password
            string hashedPassword = HashUtilites.HashString(user.Password, _hashConfig.SecretKey);

            // Save entity in Database
            var userModel = await _userRepository.AddAsync(user);

            // Generate token for the user using Jwt
            string token = AuthJwtService.GenerateTokenForUser(userModel, _jwtService);

            // Return Email and token in AuthResponse
            return new AuthResponse
            {
                Email = userModel.Email,
                Token = token
            };
        }
    }
}
