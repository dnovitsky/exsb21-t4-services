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
using SAPex.Models.Authorization.AuthRequest;
using SAPex.Models.Authorization.AuthResponse;

namespace SAPex.Services.Jwt
{
    public class JwtService
    {
        private readonly UserService _userService;
        private readonly AppSettings _appSettings;
        
        public JwtService(UserService userService, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _userService = userService;                       
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest credentials)
        {
            var user = _userService.FindByEmailAndPassword(credentials.Email, credentials.Password);
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            IList<UserRoleEntityModel> userRoles = user.UserRoles;
            List<Claim> claims = (from userRole in userRoles
                                  select new Claim(ClaimTypes.Role,
                                  userRole.FunctionalRole.Access)).ToList();
            claims.Add(new Claim(ClaimTypes.Email, credentials.Email));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.ExpDate),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticateResponse(user, tokenHandler.WriteToken(token),"");
        }
         
    }
}
