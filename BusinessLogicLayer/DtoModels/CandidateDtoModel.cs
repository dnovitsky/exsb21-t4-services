using BusinessLogicLayer.DtoModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateDtoModel: ItemDtoModel
    {
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }
 
        public string Skype { get; set; }

        public string Phone { get; set; }

        public string CurrentJob { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }

        public IList<CandidateLanguageDtoModel> CandidateLanguages { get; set; }

        public IList<CandidateTechSkillDtoModel> CandidateTechSkills { get; set; }

        public IList<CandidateSandboxDtoModel> CandidateSandboxes { get; set; }
    }
}
