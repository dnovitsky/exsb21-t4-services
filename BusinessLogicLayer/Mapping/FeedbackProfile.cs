using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    internal class FeedbackProfile : BaseProfile<FeedbackDtoModel, FeedbackEntityModel>
    {
        private readonly UserProfile userProfile = new UserProfile();

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDtoModel, FeedbackEntityModel>()
                    .ForMember(x => x.User, y => y.MapFrom(x => x.User))
                    .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackEntityModel, FeedbackDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.User, y => y.MapFrom(x => userProfile.mapToDto(x.User)))
                    .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview)));

            return new Mapper(config);
        }
    }
}
