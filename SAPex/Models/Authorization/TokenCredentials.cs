using System;

namespace SAPex.Models.Authorization
{
    public class TokenCredentials
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
