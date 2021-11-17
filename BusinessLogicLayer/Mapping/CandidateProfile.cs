using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateProfile : Profile
    {
        private readonly CandidateSandboxProfile candidateSandboxProfile = new CandidateSandboxProfile();
        private readonly CandidateTechSkillProfile candidateTechSkillProfile = new CandidateTechSkillProfile();
        private readonly CandidateLanguagesProfile candidateLanguagesProfile = new CandidateLanguagesProfile();

        public CandidateEntityModel mapNewCandidateToEM(CreateCandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateDtoModel, CandidateEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => Guid.NewGuid()))

                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.PhoneNumber))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills)));
            var mapper = new Mapper(config);

            CandidateEntityModel candidateEM = mapper.Map<CreateCandidateDtoModel, CandidateEntityModel>(candidateDto);
            return candidateEM;
        }

        public CandidateSandboxEntityModel mapNewCandidateSandBoxToEM(Guid candidateId, CreateCandidateDtoModel candidateDto, CandidateProccesEntityModel candidateProcess)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateDtoModel, CandidateSandboxEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => Guid.NewGuid()))
                    .ForMember(x => x.CandidateId, y => y.MapFrom(x => candidateId))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))

                    .ForMember(x => x.CandidateProcess, y => y.MapFrom(x => candidateProcess))

                    .ForMember(x => x.Motivation, y => y.MapFrom(x => x.Motivation))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.AvailabilityTypeId, y => y.MapFrom(x => x.AvailabillityTypeId))
                    .ForMember(x => x.TimeContact, y => y.MapFrom(x => x.TimeContact))
                    .ForMember(x => x.IsJoinToExadel, y => y.MapFrom(x => x.IsJoinToExadel))
                    .ForMember(x => x.IsAgreement, y => y.MapFrom(x => x.IsAgreement))

                    .ForMember(x => x.StackTechnologyId, y => y.MapFrom(x => x.PrimaryTechnologyId))
                    .ForMember(x => x.SandboxLanguageId, y => y.MapFrom(x => x.SandboxPreferredLanguageId)));
            var mapper = new Mapper(config);

            CandidateSandboxEntityModel candidateSandboxEM = mapper.Map<CreateCandidateDtoModel, CandidateSandboxEntityModel>(candidateDto);
            return candidateSandboxEM;
        }

        public CandidateTechSkillEntityModel mapNewCandidateTechSkillToEM(Guid candidateId, CreateCandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateDtoModel, CandidateTechSkillEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => Guid.NewGuid()))
                    .ForMember(x => x.CandidateId, y => y.MapFrom(x => candidateId))
                    .ForMember(x => x.SkillId, y => y.MapFrom(x => x.PrimaryTechnologyId)));
            var mapper = new Mapper(config);

            CandidateTechSkillEntityModel candidateTechSkillEM = mapper.Map<CreateCandidateDtoModel, CandidateTechSkillEntityModel>(candidateDto);
            return candidateTechSkillEM;
        }

        public CandidateLanguageEntityModel mapNewCandidateLanguagesEM(Guid candidateId, CreateCandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateDtoModel, CandidateLanguageEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => Guid.NewGuid()))
                    .ForMember(x => x.CandidateId, y => y.MapFrom(x => candidateId))
                    .ForMember(x => x.LanguageId, y => y.MapFrom(x => x.EnglishLanguageId))
                    .ForMember(x => x.LanguageLevelId, y => y.MapFrom(x => x.EnglishLevelId)));
            var mapper = new Mapper(config);

            CandidateLanguageEntityModel candidateLanguageEM = mapper.Map<CreateCandidateDtoModel, CandidateLanguageEntityModel>(candidateDto);
            return candidateLanguageEM;
        }

        public CandidateProccesEntityModel mapNewCandidateProcessEM(CreateCandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateDtoModel, CandidateProccesEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => Guid.NewGuid()))
                    .ForMember(x => x.StatusId, y => y.MapFrom(x => x.DefaultProcessStatusId))
                    .ForMember(x => x.TestResult, y => y.MapFrom(x => "")));
            var mapper = new Mapper(config);

            CandidateProccesEntityModel candidateProcessEM = mapper.Map<CreateCandidateDtoModel, CandidateProccesEntityModel>(candidateDto);
            return candidateProcessEM;
        }

        public CandidateEntityModel mapToEM(CandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateEntityModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills)));
            var mapper = new Mapper(config);

            CandidateEntityModel candidateEM = mapper.Map<CandidateDtoModel, CandidateEntityModel>(candidateDto);
            return candidateEM;
        }

        public CandidateDtoModel mapCandidateEMToCandidateDto(CandidateEntityModel candidateEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateEntityModel, CandidateDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => candidateLanguagesProfile.mapListToDto(x.CandidateLanguages)))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => candidateTechSkillProfile.mapListToDto(x.CandidateTechSkills)))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => candidateSandboxProfile.mapListToDto(x.CandidateSandboxes))));
            var mapper = new Mapper(config);

            CandidateDtoModel candidateDto = mapper.Map<CandidateEntityModel, CandidateDtoModel>(candidateEM);
            return candidateDto;
        }

        public IEnumerable<CandidateDtoModel> mapCandidateEMListToCandidateDtoList(IEnumerable<CandidateEntityModel> candidateEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateEntityModel, CandidateDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => candidateLanguagesProfile.mapListToDto(x.CandidateLanguages)))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => candidateTechSkillProfile.mapListToDto(x.CandidateTechSkills)))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => candidateSandboxProfile.mapListToDto(x.CandidateSandboxes))));
            var mapper = new Mapper(config);


            IList<CandidateDtoModel> candidateDtoList = new List<CandidateDtoModel>()
            {
            };

            foreach (var candidate in candidateEM)
            {
                CandidateDtoModel candidateDto = mapper.Map<CandidateEntityModel, CandidateDtoModel>(candidate);
                candidateDtoList.Add(candidateDto);
            }
            return candidateDtoList;
        }
    }
}
