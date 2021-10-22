using System;
namespace SAPex.Models
{
    public class GoogleUser
    {
        public GoogleUser()
        {
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
    }
}
