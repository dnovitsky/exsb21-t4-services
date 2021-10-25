using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class UserTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<UserSandBox> UserSandBoxes { get; set; }
        [Required]
        public List<Team> Teams { get; set; }
    }
}
