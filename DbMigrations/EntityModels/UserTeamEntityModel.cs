using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class UserTeamEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserSandBoxId { get; set; }
        public UserSandBoxEntityModel UserSandBox { get; set; }
        [Required]
        public Guid TeamId { get; set; }
        public TeamEntityModel Team { get; set; }
    }
}
