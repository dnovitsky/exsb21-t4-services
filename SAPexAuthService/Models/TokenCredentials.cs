using System;

namespace SAPexAuthService.Models
{
    public class TokenCredentials
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
