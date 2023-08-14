using System;
using System.Security.Claims;

namespace BookIt.Core.Application.Contracts.AuthService
{
	public interface IJwtService
	{
		public string CreateToken(IEnumerable<Claim> claims, int expiryInMinutes);

		public IEnumerable<Claim> VerifyToken(string token);
    }
}

