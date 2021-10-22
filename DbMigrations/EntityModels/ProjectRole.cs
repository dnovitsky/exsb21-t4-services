using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class ProjectRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Access { get; set; }
    }

    public enum Role
    {
        Admin,
        EducationManager,
        Recruiter,
        Interviewer,
        Mentor
    }
}
