using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    internal class FeedbackProfile : BaseProfile<FeedbackDtoModel, FeedbackEntityModel>
    {

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDtoModel, FeedbackEntityModel>()
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                    .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview))
                    .ForMember(x => x.CandidateProccesId, y => y.MapFrom(x => x.CandidateProccesId)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackEntityModel, FeedbackDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                    .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview))
                    .ForMember(x => x.CandidateProccesId, y => y.MapFrom(x => x.CandidateProccesId)));

            return new Mapper(config);
        }
    }
}
