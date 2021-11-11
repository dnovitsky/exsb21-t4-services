using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Controllers.Mapping
{
    public class CandidateProfile : Profile
    {
        public CandidateViewModel GetCandidateFromDto(CandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateViewModel>());
            var mapper = new Mapper(config);

            CandidateViewModel candidateVM = mapper.Map<CandidateDtoModel, CandidateViewModel>(candidateDto);
            return candidateVM;
        }

        public CandidateViewModel MapUpdatedCandidateToDto(CandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateViewModel>());
            var mapper = new Mapper(config);

            CandidateViewModel candidateVM = mapper.Map<CandidateDtoModel, CandidateViewModel>(candidateDto);
            return candidateVM;
        }

        public CandidateDtoModel MapNewCandidateToDto(CreateCandidateViewModel candidateVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateViewModel, CandidateDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.PhoneNumber))
                    .ForMember(x => x.Motivation, y => y.MapFrom(x => x.Motivation))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.AvailabillityPerDay, y => y.MapFrom(x => x.AvailabillityPerDay))
                    .ForMember(x => x.TimeContact, y => y.MapFrom(x => x.TimeContact))
                    .ForMember(x => x.IsJoinToExadel, y => y.MapFrom(x => x.IsJoinToExadel))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.IsAgreement, y => y.MapFrom(x => x.IsAgreement))

                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => CreateCandidateLanguagesLambda(x)))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => CreateCandidateTechSkillsLambda(x)))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => CreateCandidateSandboxesLambda(x))));
            var mapper = new Mapper(config);

            CandidateDtoModel candidateDto = mapper.Map<CreateCandidateViewModel, CandidateDtoModel>(candidateVM);
            return candidateDto;
        }

        private List<CandidateLanguageDtoModel> CreateCandidateLanguagesLambda(CreateCandidateViewModel x)
        {
            return new List<CandidateLanguageDtoModel>()
            {
                new CandidateLanguageDtoModel(x.LanguageId, x.EnglishLevelId),
            };
        }

        private List<CandidateTechSkillDtoModel> CreateCandidateTechSkillsLambda(CreateCandidateViewModel x)
        {
            return new List<CandidateTechSkillDtoModel>()
            {
                new CandidateTechSkillDtoModel(x.PrimaryTechnologyId),
            };
        }

        private List<CandidateSandboxDtoModel> CreateCandidateSandboxesLambda(CreateCandidateViewModel x)
        {
            return new List<CandidateSandboxDtoModel>()
            {
                new CandidateSandboxDtoModel(x.SandboxId),
            };
        }

        private Predicate<dynamic> Lambda<T>(Func<CreateCandidateViewModel, List<T>> func)
        {
            return x => func(x);
        }
    }
}
