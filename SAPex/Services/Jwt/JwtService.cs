using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SAPex.Models.Authorization.AuthResponse;

namespace SAPex.Services.Jwt
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly string _expDate;

        private List<UserEntityModel> _users = new()
        {
            new UserEntityModel
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Surname = "User",
                Email = "admin@gmail.com",
                Password = "admin",
                UserRoles = new List<UserRoleEntityModel>()
                                  {
                                      new UserRoleEntityModel
                                      {
                                          Id = Guid.NewGuid(),
                                          FunctionalRole=new FunctionalRoleEntityModel{  Access="ADMIN"}
                                      } 
                                  }
                                },
            new UserEntityModel
            {
                Id = Guid.NewGuid(),
                Name = "Normal",
                Surname = "User",
                Email = "user@gmail.com",
                Password = "user",
                UserRoles = new List<UserRoleEntityModel>()
                                  {
                                      new UserRoleEntityModel
                                      {
                                          Id = Guid.NewGuid(),
                                          FunctionalRole=new FunctionalRoleEntityModel{  Access="USER"}
                                      }
                                  }
            }
        };

        public JwtService(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public AuthenticateResponse Authenticate(string email, string password)
        {

            var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            IList<UserRoleEntityModel> userRoles = user.UserRoles;
            List<Claim> claims = (from userRole in userRoles
                                  select new Claim(ClaimTypes.Role, userRole.FunctionalRole.Access)).ToList();
            claims.Add(new Claim(ClaimTypes.Email, email));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticateResponse(user, tokenHandler.WriteToken(token),"");
        }

        public UserEntityModel GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
