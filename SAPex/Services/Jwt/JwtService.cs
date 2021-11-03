using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SAPex.Helpers;
using SAPex.Models.Authorization;

namespace SAPex.Services.Jwt
{
    public class JwtService
    {
        private readonly UserService _userService;
        private readonly AppSettings _appSettings;
        private readonly UserRefreshTokenService _refreshTokenService;

        public JwtService(UserService userService,UserRefreshTokenService refreshTokenService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _refreshTokenService = refreshTokenService;
           
        }

        public TokenCredentials Authenticate(UserCredentials credentials)
        {
            var user = _userService.FindByEmailAndPassword(credentials.Email, credentials.Password); 
            if (user == null)
                return null;

            return GenerateTokenByUser(user);
        }

        public TokenCredentials VerifyAndRefreshToken(TokenCredentials tokenRequest)
        {
            var userRefreshTokenEntityModel = _refreshTokenService.FindByRefreshToken(tokenRequest.RefreshToken);
            if (IsValidToken(userRefreshTokenEntityModel, tokenRequest))
            {
                var user = _userService.FindById(userRefreshTokenEntityModel.UserId);
                return GenerateTokenByUser(user);  
            }
            return null;    
        }

        public bool RevokeToken(string refreshToken)
        {
            var userRefresh = _refreshTokenService.FindByRefreshToken(refreshToken);
            if (userRefresh != null)
            {
                userRefresh.IsRevoked = true;
                _refreshTokenService.Update(userRefresh);
                return true;

            }
            return false;
        }

        private TokenCredentials GenerateTokenByUser(UserEntityModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            IList<UserRoleEntityModel> userRoles = user.UserRoles;
            List<Claim> claims = (from userRole in userRoles
                                  select new Claim(ClaimTypes.Role,
                                  userRole.FunctionalRole.Access)).ToList();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.ExpDate),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            
            return new TokenCredentials
            {
                AccessToken=tokenHandler.WriteToken(token),
                RefreshToken=GenerateRefreshToken(token.Id,user.Id)
            };

        }

        private string GenerateRefreshToken(string jwtId, Guid userId)
        {
            var refreshTokenEntityModel = new UserRefreshTokenEntityModel
            {
                JwtId = jwtId, //token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserId = userId,// user.Id
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
                Token = RefreshTokenGenerateString(35) + Guid.NewGuid()
            };
            _refreshTokenService.Add(refreshTokenEntityModel);
            return refreshTokenEntityModel.Token;

        }

        private string RefreshTokenGenerateString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(x => x[random.Next(x.Length)]).ToArray());
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
                ClockSkew = TimeSpan.Zero

            };    
        }

        private bool IsValidToken(UserRefreshTokenEntityModel  userRefreshTokenEntityModel,TokenCredentials tokenRequest)
        {
            try
            {
                JwtSecurityTokenHandler jwtTokenHandler = new();
                var tokenInVerification = jwtTokenHandler.ValidateToken(tokenRequest.AccessToken, GetTokenValidationParameters(), out var validatedToken);

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
                var jwtId = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                return IsValidRefreshToken(userRefreshTokenEntityModel, jwtId);

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private bool IsValidRefreshToken(UserRefreshTokenEntityModel refresh,string jwtId)
        {

            if (refresh == null || refresh.IsUsed || refresh.IsRevoked || refresh.JwtId != jwtId || DateTime.UtcNow > refresh.ExpiryDate)
            {
                return false;
            }
   
             refresh.IsUsed = true;
            _refreshTokenService.Update(refresh);
            return true;
        }

    }
}
