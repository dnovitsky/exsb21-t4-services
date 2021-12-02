using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateProccessTestTasksProfile : BaseProfile<CandidateProccessTestTasksDtoModel, CandidateProccessTestTasksEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProccessTestTasksDtoModel, CandidateProccessTestTasksEntityModel>()
                    .ForMember(x => x.TestFileId, y => y.MapFrom(x => x.TestFileId)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProccessTestTasksEntityModel, CandidateProccessTestTasksDtoModel>()
                    .ForMember(x => x.TestFileId, y => y.MapFrom(x => x.TestFileId)));

            return new Mapper(config);
        }
    }
}
