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
                    .ForMember(x => x.MentoreGrade, y => y.MapFrom(x => x.MentoreGrade))
                    .ForMember(x => x.InterviewerGrade, y => y.MapFrom(x => x.InterviewerGrade))
                    .ForMember(x => x.AdminGrade, y => y.MapFrom(x => x.AdminGrade))
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
                    .ForMember(x => x.MentoreGrade, y => y.MapFrom(x => x.MentoreGrade))
                    .ForMember(x => x.InterviewerGrade, y => y.MapFrom(x => x.InterviewerGrade))
                    .ForMember(x => x.AdminGrade, y => y.MapFrom(x => x.AdminGrade))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.UserReview, y => y.MapFrom(x => x.UserReview))
                    .ForMember(x => x.CandidateProccesId, y => y.MapFrom(x => x.CandidateProccesId)));

            return new Mapper(config);
        }
    }
}
