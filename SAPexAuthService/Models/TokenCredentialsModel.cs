using System;

namespace SAPexAuthService.Models
{
    public class TokenCredentialsModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
