using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        
        public Guid LocationId { get; set; }
        public virtual LocationEntityModel Location { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Skype { get; set; }
        [Required]
        public string Phone { get; set; }

        public virtual IList<UserSandBoxEntityModel> UserSanboxes { get; set; }
        public virtual IList<UserTechSkillEntityModel> UserTechSkills { get; set; }
        public virtual IList<UserFunctionalRoleEntityModel> UserRoles { get; set; }
        public virtual IList<UserLanguageEntityModel> UserLanguages { get; set; }
        public virtual IList<FeedbackEntityModel> Feedbacks { get; set; }

        public virtual IList<UserStackTechnologyEntityModel> UserStackTechnologies { get; set; }
    }
}
