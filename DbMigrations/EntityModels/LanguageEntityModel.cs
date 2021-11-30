using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class LanguageEntityModel : NameEntityModel
    {
        public LanguageEntityModel() : base()
        {
            CandidateLanguages = new List<CandidateLanguageEntityModel>();
            UserLanguages = new List<UserLanguageEntityModel>();
            SandboxLanguages = new List<SandboxLanguageEntityModel>();
        }

        public virtual IList<CandidateLanguageEntityModel> CandidateLanguages  { get; set; }
        public virtual IList<UserLanguageEntityModel> UserLanguages { get; set; }
        public virtual IList<SandboxLanguageEntityModel> SandboxLanguages { get; set; }
    }
}
