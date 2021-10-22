using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using  DbMigrations.Models;

namespace DbMigrations.EntityModels
{
    public class MentorRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ProjectRole ProjectRoleId { get; set; }
        [Required]
        public MentorSandBox MentorSandBoxId { get; set; }
    }
}
