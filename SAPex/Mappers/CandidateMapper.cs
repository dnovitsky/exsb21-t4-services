using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Controllers.Mapping
{
    public class CandidateMapper : Profile
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
                    .ForMember(x => x.AvailabillityTypeId, y => y.MapFrom(x => x.AvailabillityTypeId))
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

        public CandidateViewModel MapCandidateDtoToVM(CandidateDtoModel candidateVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => x.CandidateLanguages))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => x.CandidateTechSkills))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => x.CandidateSandboxes)));

            var mapper = new Mapper(config);

            CandidateViewModel candidateDto = mapper.Map<CandidateDtoModel, CandidateViewModel>(candidateVM);
            return candidateDto;
        }

        public IEnumerable<CandidateViewModel> MapCandidateDtoToVM(IEnumerable<CandidateDtoModel> candidateEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => x.CandidateLanguages))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => x.CandidateTechSkills))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => x.CandidateSandboxes)));

            var mapper = new Mapper(config);

            IList<CandidateViewModel> candidateDtoList = new List<CandidateViewModel>()
            {
                mapper.Map<CandidateDtoModel, CandidateViewModel>(candidateEM.FirstOrDefault()),
            };
            int i = 0;
            foreach (var candidate in candidateEM)
            {
                if (i != 0)
                {
                    CandidateViewModel candidateDto = mapper.Map<CandidateDtoModel, CandidateViewModel>(candidate);
                    candidateDtoList.Add(candidateDto);
                }

                i++;
            }

            return candidateDtoList;
        }

        private Dictionary<string, Guid> _DefaultValues = new Dictionary<string, Guid>()
        {
            { "DefaultProcessId",  Guid.Parse("") },
            { "DefaultLanguageId",  Guid.Parse("") },
            { "3",  Guid.Parse("") },
            { "4",  Guid.Parse("") },
        };
    }
}
