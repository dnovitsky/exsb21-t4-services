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
        public string Id_token { get; set; }

        public void Set(int id, string email, string refresh_token, long created_in)
        {
            Id = id;
            Email = email;
            Refresh_token = refresh_token;
            Created_in = created_in;
        }

        public void Set(string email, long created_in)
        {
            Email = email;
            Created_in = created_in;
        }
    }
}
