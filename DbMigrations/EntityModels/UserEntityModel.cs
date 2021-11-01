using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class UserEntityModel
    {
        public UserEntityModel()
        {
            UserSanboxes = new List<UserSandBoxEntityModel>();
            UserTechSkills = new List<UserTechSkillEntityModel>();
            UserRoles = new List<UserFunctionalRoleEntityModel>();
            UserLanguages = new List<UserLanguageEntityModel>();
            Feedbacks = new List<FeedbackEntityModel>();
            UserStackTechnologies = new List<UserStackTechnologyEntityModel>();


        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Skype { get; set; }
        [Required]
        public string Phone { get; set; }

        public IList<UserSandBoxEntityModel> UserSanboxes { get; set; }
        public IList<UserTechSkillEntityModel> UserTechSkills { get; set; }
        public IList<UserFunctionalRoleEntityModel> UserRoles { get; set; }
        public IList<UserLanguageEntityModel> UserLanguages { get; set; }
        public IList<FeedbackEntityModel> Feedbacks { get; set; }

        public IList<UserStackTechnologyEntityModel> UserStackTechnologies { get; set; }

    }
}
