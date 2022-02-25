using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.API.Common
{
    public class JwtGenerate
    {
        private readonly JwtConfig _jwtConfig;

        public JwtGenerate(IOptionsMonitor<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.CurrentValue;
        }

        public string GenerateJwtToken(ApplicationUser user, IList<string> roleList = null)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(nameof(ApplicationUser.Id), user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer,
                Expires = DateTime.UtcNow.AddHours(_jwtConfig.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),

            };
            if (roleList != null)
                foreach (var item in roleList)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, item));
                }

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}