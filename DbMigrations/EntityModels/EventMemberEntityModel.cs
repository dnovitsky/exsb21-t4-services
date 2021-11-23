using System;
using System.ComponentModel.DataAnnotations.Schema;
using DbMigrations.EntityModels.BaseModels;

namespace DbMigrations.EntityModels
{
    public class EventMemberEntityModel : NameEntityModel
    {
        public Guid MemberId { get; set; }

        public string MemberEmail { get; set; }

        public string MemberRole { get; set; }

        public string ResponseStatus { get; set; }

        public Guid EventId { get; set; }
        
        [ForeignKey(nameof(EventId))]
        public virtual EventEntityModel Event{ get; set; }
    }
}
