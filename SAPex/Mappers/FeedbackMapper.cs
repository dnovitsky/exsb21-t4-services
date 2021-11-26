using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using SAPex.Mappers.Base;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class FeedbackMapper : BaseMapper<FeedbackDtoModel, FeedbackViewModel>
    {
        protected override Mapper ViewToDtoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackViewModel, FeedbackDtoModel>()
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                    .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview))
                    .ForMember(x => x.CandidateProccesId, y => y.MapFrom(x => x.CandidateProccesId)));

            return new Mapper(config);
        }

        protected override Mapper DtoToViewMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDtoModel, FeedbackViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                    .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview))
                    .ForMember(x => x.CandidateProccesId, y => y.MapFrom(x => x.CandidateProccesId)));

            return new Mapper(config);
        }

        public IEnumerable<FeedbackViewModel> MapListToView(IEnumerable<FeedbackDtoModel> feedbacksDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDtoModel, FeedbackViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.RatingId, y => y.MapFrom(x => x.RatingId))
                .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview))
                .ForMember(x => x.CandidateProccesId, y => y.MapFrom(x => x.CandidateProccesId)));
            var mapper = new Mapper(config);

            IList<FeedbackViewModel> feedbacksViewList = new List<FeedbackViewModel>() { };
            int i = 0;
            foreach (var feedback in feedbacksDM)
            {
                FeedbackViewModel feedbackVM = mapper.Map<FeedbackDtoModel, FeedbackViewModel>(feedback);
                feedbacksViewList.Add(feedbackVM);
            }

            return feedbacksViewList;
        }
    }
}
