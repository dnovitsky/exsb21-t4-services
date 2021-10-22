using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class MentorTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<MentorSandBox> MentorSandBoxId { get; set; }
        [Required]
        public List<Team> TeamId { get; set; }
    }
}
