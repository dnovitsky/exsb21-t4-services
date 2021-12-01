using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SAPexAuthService.Models;

namespace SAPexAuthService.Services.Utils
{
    public class TokenUtil
    {
        private readonly AppSettingsModel _appSettings;
        public TokenUtil(AppSettingsModel appSettings)
        {
            _appSettings = appSettings;
        }

        public string GetJwtToken(string email, List<string> roles, Guid jti)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            List<Claim> claims = (from role in roles
                                  select new Claim(ClaimTypes.Role,
                                   role)).ToList();
            claims.Add(new Claim(ClaimTypes.Email, email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, jti.ToString()));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.ExpMinute),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetRefreshToken(out int expMonths)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            expMonths = _appSettings.ExpMonth;
            return new string(Enumerable.Repeat(chars, _appSettings.RefreshLength)
                .Select(x => x[random.Next(x.Length)]).ToArray());
        }

        public bool IsValidToken(string accessToken, out string jti)
        {
            jti = null;
            try
            {
                JwtSecurityTokenHandler jwtTokenHandler = new();
                var tokenInVerification = jwtTokenHandler.ValidateToken(accessToken, GetTokenValidationParameters(), out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                    {
                        return false;
                    }
                }

                var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expiryDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(utcExpiryDate).ToUniversalTime();

                if (expiryDate > DateTime.UtcNow)
                {
                    return false;
                }

                jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero,
            };
        }
    }
}
