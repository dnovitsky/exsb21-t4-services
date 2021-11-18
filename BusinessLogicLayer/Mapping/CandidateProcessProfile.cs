using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateProcessProfile : BaseProfile<CandidateProcessDtoModel, CandidateProccesEntityModel>
    {
        private readonly FeedbackProfile feedbackProfile = new FeedbackProfile();
        private readonly StatusProfile statusProfile = new StatusProfile();

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcessDtoModel, CandidateProccesEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status))
                    .ForMember(x => x.TestResult, y => y.MapFrom(x => x.TestResult))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Feedback, y => y.MapFrom(x => x.Feedback)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProccesEntityModel, CandidateProcessDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Status, y => y.MapFrom(x => statusProfile.mapToDto(x.Status)))
                    .ForMember(x => x.TestResult, y => y.MapFrom(x => x.TestResult))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Feedback, y => y.MapFrom(x => feedbackProfile.mapToDto(x.Feedback))));

            return new Mapper(config);
        }
    }
}
