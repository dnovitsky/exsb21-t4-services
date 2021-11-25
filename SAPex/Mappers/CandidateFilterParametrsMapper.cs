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
                    .ForMember(x => x.Locations, y => y.MapFrom(x => x.Locations))
                    .ForMember(x => x.Mentors, y => y.MapFrom(x => x.Mentors))
                    .ForMember(x => x.Sandboxes, y => y.MapFrom(x => x.Sandboxes))
                    .ForMember(x => x.Statuses, y => y.MapFrom(x => x.Statuses)));

            var mapper = new Mapper(config);

            CandidateFilterParametrsDtoModel candidateFilterParametrsDto = mapper.Map<CandidateFilterParametrsViewModel, CandidateFilterParametrsDtoModel>(candidateFilterParametrsView);
            return candidateFilterParametrsDto;
        }
    }
}
