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
        public CreateCandidateDtoModel MapNewCandidateToDto(CreateCandidateViewModel candidateVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateViewModel, CreateCandidateDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.PhoneNumber, y => y.MapFrom(x => x.PhoneNumber))
                    .ForMember(x => x.Motivation, y => y.MapFrom(x => x.Motivation))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.AvailabillityPerDay, y => y.MapFrom(x => x.AvailabillityPerDay))
                    .ForMember(x => x.TimeContact, y => y.MapFrom(x => x.TimeContact))
                    .ForMember(x => x.IsJoinToExadel, y => y.MapFrom(x => x.IsJoinToExadel))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.IsAgreement, y => y.MapFrom(x => x.IsAgreement))
                    .ForMember(x => x.EnglishLevelId, y => y.MapFrom(x => x.EnglishLevelId))
                    .ForMember(x => x.SandboxPreferredLanguageId, y => y.MapFrom(x => x.SandboxPreferredLanguageId))
                    .ForMember(x => x.PrimaryTechnologyId, y => y.MapFrom(x => x.PrimaryTechnologyId))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId)));
            var mapper = new Mapper(config);

            CreateCandidateDtoModel candidateDto = mapper.Map<CreateCandidateViewModel, CreateCandidateDtoModel>(candidateVM);
            return candidateDto;
        }
    }
}
