using DbMigrations.EntityModels.BaseModels;
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
    public class SandboxEntityModel : NameEntityModel
    {
        public SandboxEntityModel() : base()
        {
            UserSandboxes = new List<UserSandBoxEntityModel>();
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
            Teams = new List<TeamEntityModel>();
            SandboxStackTechnologies = new List<SandboxStackTechnologyEntityModel>();
            SandboxLanguages = new List<SandboxLanguageEntityModel>();
        }

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

        [Required]
        [DefaultValue(StatusName.Draft)]
        private StatusName status;
        
        public StatusName Status
        {
            get
            {
               if (status == StatusName.Draft)
               {
                    return status;
               }

               if( status == StatusName.Active && DateTime.Now < StartRegistration )
               {
                    return status;
               }

               if( StartRegistration <= DateTime.Now && DateTime.Now <= EndRegistration )
               {
                    status = StatusName.Registration;
                    return status;
               }

               if ( EndRegistration < DateTime.Now && DateTime.Now < StartDate )
               {
                    status = StatusName.Application;
                    return status;
               }

               if ( StartDate <= DateTime.Now && DateTime.Now <= EndDate )
               {
                    status = StatusName.Inprogress;
                    return status;
               }

               if ( DateTime.Now > EndDate)
               {
                    status = StatusName.Archive;
               }

               return status;
            }
            set { status = value; }
        }


        public virtual IList<UserSandBoxEntityModel> UserSandboxes  { get; set; }
        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes  { get; set; }
        public virtual IList<TeamEntityModel> Teams { get; set; }
        public virtual IList<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }
        public virtual IList<SandboxLanguageEntityModel> SandboxLanguages { get; set; }


    }

    public enum StatusName { Draft, Active, Registration, Application, Inprogress, Archive };
}
