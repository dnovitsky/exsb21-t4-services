using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateFilterParametrsMapper : Profile
    {
        public CandidateFilterParametrsDalModel MapFromDtoToEntity(CandidateFilterParametrsDtoModel candidateFilterParametrsDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateFilterParametrsDtoModel, CandidateFilterParametrsDalModel>()
                    .ForMember(x => x.Locations, y => y.MapFrom(x => x.Locations))
                    .ForMember(x => x.Mentors, y => y.MapFrom(x => x.Mentors))
                    .ForMember(x => x.Sandboxes, y => y.MapFrom(x => x.Sandboxes))
                    .ForMember(x => x.Statuses, y => y.MapFrom(x => x.Statuses)));

            var mapper = new Mapper(config);

            CandidateFilterParametrsDalModel candidateFilterParametrsEM = mapper.Map<CandidateFilterParametrsDtoModel, CandidateFilterParametrsDalModel>(candidateFilterParametrsDto);
            return candidateFilterParametrsEM;
        }
    }
}
