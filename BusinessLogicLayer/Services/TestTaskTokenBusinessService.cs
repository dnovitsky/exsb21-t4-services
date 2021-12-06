using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TestTaskTokenBusinessService : ITestTaskTokenBusinessService
    {
        private readonly string secretString = "PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f";

        public string GetToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretString);



            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, email) }),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretString)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero,
            };
        }

        public string GetEmailByToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new();
                var tokenInVerification = tokenHandler.ValidateToken(token, GetTokenValidationParameters(), out var validatedToken);

                if (validatedToken is JwtSecurityToken checkToken)
                {
                    var result = checkToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                    {
                        return null;
                    }
                }

                string email = tokenInVerification.FindFirst(ClaimTypes.Email.ToString()).Value;

                return email;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }
}
