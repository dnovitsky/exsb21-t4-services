using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DbMigrations.EntityModels
{
    public class UserSandBox
    {
        [Key]
        public int Id { get; set; }
        public List<Sandbox> SandBoxes {get;set;}
        public List<UserRole> UserRoles { get; set; }
        public List<User> Users { get; set; }
    }
}
