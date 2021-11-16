using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SandboxEntityModel
    {
        public SandboxEntityModel()
        {
            UserSandboxes = new List<UserSandBoxEntityModel>();
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
            Teams = new List<TeamEntityModel>();
            SandboxStackTechnologies = new List<SandboxStackTechnologyEntityModel>();
            SandboxLanguages = new List<SandboxLanguageEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaxCandidates { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [DefaultValue(null)]
        public DateTime? EndDate { get; set; }
        [Required]
        public DateTime StartRegistration { get; set; }
        [DefaultValue(null)]
        public DateTime? EndRegistration { get; set; }

        //[Required]
        //[DefaultValue(0)]
        //public int Status 
        //{
        //    get
        //    {
        //        if( Status == 1) // 1 - в архиве, 0 - активный
        //        {
        //            return 1;
        //        }

        //        if( DateTime.Now > EndDate)
        //        {
        //            return 1;
        //        }



        //        return 0; 
        //    } 
        //    set { value = 0 } }


        public virtual IList<UserSandBoxEntityModel> UserSandboxes  { get; set; }
        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes  { get; set; }
        public virtual IList<TeamEntityModel> Teams { get; set; }
        public virtual IList<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }
        public virtual IList<SandboxLanguageEntityModel> SandboxLanguages { get; set; }


    }
}
