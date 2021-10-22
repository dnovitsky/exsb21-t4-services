using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.Models
{
    public class ProjectRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MentorRole Access { get; set; }
    }

    public enum MentorRole
    {
        Admin,
        EducationManager,
        Recruiter,
        Interviewer,
        Mentor
    }
}
