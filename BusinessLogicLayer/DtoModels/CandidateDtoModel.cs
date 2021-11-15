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

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string AvailabillityPerDay { get; set; }

        public string TimeContact { get; set; }

        public bool IsJoinToExadel { get; set; }

        public bool IsAgreement { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }

        public List<CandidateLanguageDtoModel> CandidateLanguages { get; set; }
        public List<CandidateTechSkillDtoModel> CandidateTechSkills { get; set; }
        public List<CandidateSandboxDtoModel> CandidateSandboxes { get; set; }
    }
}
