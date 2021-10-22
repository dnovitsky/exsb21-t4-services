using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DbMigrations.Models;

namespace DbMigrations.EntityModels
{
    public class MentorSandBox
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Sandbox SandBoxId {get;set;}
        [Required]
        public User UserId { get; set; }
    }
}
