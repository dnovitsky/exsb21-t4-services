﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CreateCandidateDtoModel
    {
        public Guid SandboxId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Guid EnglishLevelId { get; set; }

        // Default Language Id
        public Guid EnglishLanguageId { get; set; }

        // Default Process Status Id
        public Guid DefaultProcessStatusId { get; set; }

        public Guid SandboxPreferredLanguageId { get; set; }

        public Guid PrimaryTechnologyId { get; set; }

        public string PhoneNumber { get; set; }

        public string Skype { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public Guid AvailabillityTypeId { get; set; }

        public string TimeContact { get; set; }

        public bool IsJoinToExadel { get; set; }

        public bool IsAgreement { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }
    }
}
