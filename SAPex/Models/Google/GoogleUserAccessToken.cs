using System;
namespace SAPex.Models
{
    public class GoogleUserAccessToken
    {
        public int Id { get; set; }
        public long Expires_in { get; set; }
        public long Created_in { get; set; }
        public string Email { get; set; }
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public string Scope { get; set; }
        public string Token_type { get; set; }  
    }
}
