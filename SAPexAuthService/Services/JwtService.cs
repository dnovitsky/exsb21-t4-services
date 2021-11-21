using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SAPexAuthService.Models;

namespace SAPexAuthService.Services
{
    public class JwtService
    {
        private readonly AuthUserService _userService;
        private readonly AppSettingsModel _appSettings;
        private readonly AuthUserRefreshTokenService _refreshTokenService;

        public JwtService(AuthUserService userService, AuthUserRefreshTokenService refreshTokenService, IOptions<AppSettingsModel> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<TokenCredentialsModel> AuthenticateAsync(UserCredentialsModel credentials)
        {
            var user = await _userService.FindByEmailAsync(credentials.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(credentials.Password,user.Password))
            {
                return null;
            }
            var tokenCredentialsModel = await GenerateTokenByUserAsync(user);
            return tokenCredentialsModel;
        }

        public async Task<TokenCredentialsModel> VerifyAndRefreshTokenAsync(TokenCredentialsModel tokenRequest)
        {
            var userRefreshTokenEntityModel = await _refreshTokenService.FindByRefreshTokenAsync(tokenRequest.RefreshToken);
   
            if (IsValidToken(userRefreshTokenEntityModel, tokenRequest))
            {
                var user = await _userService.FindByIdAsync(userRefreshTokenEntityModel.UserId);
                var tokenCredentialsModel = await GenerateTokenByUserAsync(user);
                return tokenCredentialsModel;
            }

            return null;
        }

        public async Task<bool> RevokeTokenAsync(string refreshToken)
        {
            var userRefresh = await _refreshTokenService.FindByRefreshTokenAsync(refreshToken);
            if (userRefresh != null)
            {
                userRefresh.IsRevoked = true;
                _refreshTokenService.Update(userRefresh);
                return true;
            }

            return false;
        }

        private async Task<TokenCredentialsModel> GenerateTokenByUserAsync(UserEntityModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            IList<UserFunctionalRoleEntityModel> userRoles = user.UserRoles;
            List<Claim> claims = (from userRole in userRoles
                                  select new Claim(ClaimTypes.Role,
                                  userRole.FunctionalRole.Name)).ToList();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.ExpDate),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = await GenerateRefreshToken(token.Id, user.Id);
            return new TokenCredentialsModel
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken,
            };
        }

        private async Task<string> GenerateRefreshToken(string jwtId, Guid userId)
        {
            var refreshTokenEntityModel = new UserRefreshTokenEntityModel
            {
                JwtId = jwtId, // token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserId = userId, // user.Id
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(_appSettings.ExpMonth),
                Token = RefreshTokenGenerateString(35) + Guid.NewGuid(),
            };
            await _refreshTokenService.Add(refreshTokenEntityModel);
            return refreshTokenEntityModel.Token;
        }

        private string RefreshTokenGenerateString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(x => x[random.Next(x.Length)]).ToArray());
        }

        private bool IsValidToken(UserRefreshTokenEntityModel userRefreshTokenEntityModel, TokenCredentialsModel tokenRequest)
        {
            try
            {
                JwtSecurityTokenHandler jwtTokenHandler = new ();
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

        private bool IsValidRefreshToken(UserRefreshTokenEntityModel refresh, string jwtId)
        {
            if (refresh == null || refresh.IsUsed || refresh.IsRevoked || refresh.JwtId != jwtId || DateTime.UtcNow > refresh.ExpiryDate)
            {
                return false;
            }

            refresh.IsUsed = true;
            _refreshTokenService.Update(refresh);
            return true;
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
