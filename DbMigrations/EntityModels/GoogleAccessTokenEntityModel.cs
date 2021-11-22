using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbMigrations.EntityModels
{
    public class GoogleAccessTokenEntityModel
    {
        public Guid Id { get; set; }
        public long Expires_in { get; set; }
        public long Created_in { get; set; }
        public Guid UserId { get; set; }
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public string Token_type { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntityModel User { get; set; }
    }
}
