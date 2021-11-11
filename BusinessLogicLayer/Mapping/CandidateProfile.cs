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
        public CandidateEntityModel mapToEM(CandidateDtoModel candidateDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => Guid.NewGuid()))
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

        public CandidateDtoModel mapToDto(CandidateEntityModel candidateEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateEntityModel, CandidateDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => x.CandidateLanguages))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => x.CandidateTechSkills))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => x.CandidateSandboxes)));
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            CandidateDtoModel candidateDto = mapper.Map<CandidateEntityModel, CandidateDtoModel>(candidateEM);
            return candidateDto;
        }

        public IEnumerable<CandidateDtoModel> mapListToDto(IEnumerable<CandidateEntityModel> candidateEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateEntityModel, CandidateDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => x.CandidateLanguages))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => x.CandidateTechSkills))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => x.CandidateSandboxes)));
            var mapper = new Mapper(config);


            IList<CandidateDtoModel> candidateDtoList = new List<CandidateDtoModel>()
            {
                mapper.Map<CandidateEntityModel, CandidateDtoModel>(candidateEM.FirstOrDefault())
            };
            int i = 0;
            foreach (var candidate in candidateEM)
            {
                if (i != 0)
                {
                    CandidateDtoModel candidateDto = mapper.Map<CandidateEntityModel, CandidateDtoModel>(candidate);
                    candidateDtoList.Add(candidateDto);
                }
                i++;
            }
            return candidateDtoList;
        }
    }
}
