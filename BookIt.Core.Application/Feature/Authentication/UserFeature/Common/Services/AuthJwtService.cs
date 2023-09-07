using System;
using System.Security.Claims;
using BookIt.Core.Application.Contracts.AuthService;
using BookIt.Core.Domain.Authentication.Entity;
using BookIt.Core.Domain.Authentication.Model;

namespace BookIt.Core.Application.Feature.Authentication.UserFeature.Common.Services
{
	public static class AuthJwtService
	{
		public static string GenerateTokenForUser(User user, IJwtService jwtService)
		{
			// Make claims for user
			IEnumerable<Claim> claims = new List<Claim>()
			{
				new Claim("email", user.Email),
				new Claim("role", user.UserRole.ToString())
			};

			// convert claim to token
			// return token
			return jwtService.CreateToken(claims, 30);
		}
	}
}

