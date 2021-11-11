using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbMigrations.EntityModels
{
    public class UserRefreshTokenEntityModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntityModel User { get; set; }
    }
}
