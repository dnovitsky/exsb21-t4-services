using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateFilterParametrsMapper : Profile
    {
        public CandidateFilterParametrsEntityModel MapFromDtoToEntity(CandidateFilterParametrsDtoModel candidateFilterParametrsDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateFilterParametrsDtoModel, CandidateFilterParametrsEntityModel>()
                    .ForMember(x => x.LocationId, y => y.MapFrom(x => x.LocationId))
                    .ForMember(x => x.MentorId, y => y.MapFrom(x => x.MentorId))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))
                    .ForMember(x => x.SearchingStatus, y => y.MapFrom(x => x.SearchingStatus)));

            var mapper = new Mapper(config);

            CandidateFilterParametrsEntityModel candidateFilterParametrsEM = mapper.Map<CandidateFilterParametrsDtoModel, CandidateFilterParametrsEntityModel>(candidateFilterParametrsDto);
            return candidateFilterParametrsEM;
        }
    }
}
