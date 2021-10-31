using System;
using DbMigrations.EntityModels;

namespace SAPex.Models.Authorization.AuthResponse
{
    public class AuthenticateResponse
    {
        public AuthenticateResponse(UserEntityModel user, string accessToken,string refreshToken)
        {
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Location = user.Location;
            Skype = user.Skype;
            Phone = user.Phone;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
