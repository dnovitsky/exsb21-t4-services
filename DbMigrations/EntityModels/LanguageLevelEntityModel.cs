using DbMigrations.EntityModels.BaseModels;
using System.Collections.Generic;

namespace DbMigrations.EntityModels
{
    public class LanguageLevelEntityModel : OrderLevelEntityModel
    {
        public LanguageLevelEntityModel()
        {
            CandidateLanguages = new List<CandidateLanguageEntityModel>();
            UserLanguages = new List<UserLanguageEntityModel>();
        }

        public IList<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        public IList<UserLanguageEntityModel> UserLanguages { get; set; }
    }
}
