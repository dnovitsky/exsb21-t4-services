using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbMigrations.EntityModels
{
    public class GoogleUserAccessTokenEntityModel
    {
        [Key]
        [ForeignKey("UserEntityModel")]
        public Guid Id { get; set; }
        public long Expires_in { get; set; }
        public long Created_in { get; set; }
        public string Email { get; set; }
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public string Scope { get; set; }
        public string Token_type { get; set; }
        public string Id_token { get; set; }
        public virtual UserEntityModel UserEntityModel {get; set;}
    }
}
