using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateProcessProfile : BaseProfile<CandidateProcessDtoModel, CandidateProcesEntityModel>
    {
        private readonly FeedbackProfile feedbackProfile = new FeedbackProfile();
        private readonly StatusProfile statusProfile = new StatusProfile();
        private readonly CandidateProcessTestTasksProfile candidateProccessTestTasksProfile = new CandidateProcessTestTasksProfile();

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcessDtoModel, CandidateProcesEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status))
                    .ForMember(x => x.TestResult, y => y.MapFrom(x => x.TestResult))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Feedbacks, y => y.MapFrom(x => x.Feedbacks))
                    .ForMember(x => x.СandidateProccessTestTasks, y => y.MapFrom(x => candidateProccessTestTasksProfile.mapDtoListToEM(x.СandidateProccessTestTasks))));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcesEntityModel, CandidateProcessDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Status, y => y.MapFrom(x => statusProfile.mapToDto(x.Status)))
                    .ForMember(x => x.TestResult, y => y.MapFrom(x => x.TestResult))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Feedbacks, y => y.MapFrom(x => feedbackProfile.mapListToDto(x.Feedbacks)))
                    .ForMember(x => x.СandidateProccessTestTasks, y => y.MapFrom(x => candidateProccessTestTasksProfile.mapListToDto(x.СandidateProccessTestTasks))));

            return new Mapper(config);
        }
    }
}
