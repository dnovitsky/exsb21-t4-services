using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateProcessTestTasksProfile : BaseProfile<CandidateProcessTestTaskDtoModel, CandidateProcessTestTaskEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcessTestTaskDtoModel, CandidateProcessTestTaskEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.CandidateProcessId, y => y.MapFrom(x => x.CandidateProcessId))
                    .ForMember(x => x.TestFileId, y => y.MapFrom(x => x.TestFileId))
                    .ForMember(x => x.CandidateResponseTestFileId, y => y.MapFrom(x => x.CandidateResponseTestFileId))
                    .ForMember(x => x.SendTestDate, y => y.MapFrom(x => x.SendTestDate))
                    .ForMember(x => x.EndTestDate, y => y.MapFrom(x => x.EndTestDate))
                    .ForMember(x => x.Token, y => y.MapFrom(x => x.Token)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcessTestTaskEntityModel, CandidateProcessTestTaskDtoModel>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CandidateProcessId, y => y.MapFrom(x => x.CandidateProcessId))
                .ForMember(x => x.TestFileId, y => y.MapFrom(x => x.TestFileId))
                .ForMember(x => x.CandidateResponseTestFileId, y => y.MapFrom(x => x.CandidateResponseTestFileId))
                .ForMember(x => x.SendTestDate, y => y.MapFrom(x => x.SendTestDate))
                .ForMember(x => x.EndTestDate, y => y.MapFrom(x => x.EndTestDate))
                .ForMember(x => x.Token, y => y.MapFrom(x => x.Token)));

            return new Mapper(config);
        }
    }
}
