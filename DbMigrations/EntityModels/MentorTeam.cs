using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DbMigrations.Models;

namespace DbMigrations.EntityModels
{
    public class MentorTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<MentorSandBox> MentorSandBoxList { get; set; }
        [Required]
        public Team TeamId { get; set; }
    }
}
