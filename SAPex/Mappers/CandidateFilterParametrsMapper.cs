using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class CandidateFilterParametrsMapper : Profile
    {
        public CandidateFilterParametrsDtoModel MapFromViewToDto(CandidateFilterParametrsViewModel candidateFilterParametrsView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateFilterParametrsViewModel, CandidateFilterParametrsDtoModel>()
                    .ForMember(x => x.LocationId, y => y.MapFrom(x => x.LocationId))
                    .ForMember(x => x.MentorId, y => y.MapFrom(x => x.MentorId))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))
                    .ForMember(x => x.SearchingStatus, y => y.MapFrom(x => x.SearchingStatus)));

            var mapper = new Mapper(config);

            CandidateFilterParametrsDtoModel candidateFilterParametrsDto = mapper.Map<CandidateFilterParametrsViewModel, CandidateFilterParametrsDtoModel>(candidateFilterParametrsView);
            return candidateFilterParametrsDto;
        }
    }
}
