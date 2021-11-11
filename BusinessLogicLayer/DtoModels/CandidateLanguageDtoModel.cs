using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateLanguageDtoModel
    {
        public CandidateLanguageDtoModel(Guid langageId, Guid langageLevelId) {
            Language = new LanguageDtoModel();
            LanguageLevel = null;
        }

        public Guid Id { get; set; }

        public LanguageDtoModel Language { get; set; }

        public LanguageLevelDtoModel LanguageLevel { get; set; }
    }
}
