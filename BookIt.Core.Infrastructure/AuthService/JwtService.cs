using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using BookIt.Core.Application.Contracts.AuthService;
using BookIt.Core.Application.Utilities;
using BookIt.Core.Infrastructure.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookIt.Core.Infrastructure.AuthService
{
	public class JwtService : IJwtService
	{
        private readonly JwtConfig _jwtConfig;

        public JwtService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string CreateToken(IEnumerable<Claim> claims, int expirationInMinutes)
        {
            // Generate security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);
            // create jwtToken
            var token = new JwtSecurityToken(
                   issuer: "your-issuer",
                   audience: "your-audience",
                   claims: claims,
                   expires: DateTimeUtilities.AddTime(expirationInMinutes, TimeUnitEnum.Minute),
                   signingCredentials: signingCredentials
               );
            // return writeToken
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> VerifyToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}

