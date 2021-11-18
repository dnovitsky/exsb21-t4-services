using System;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class InterviewEventProfile : BaseProfile<InterviewEventDtoModel, InterviewEventEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InterviewEventDtoModel, InterviewEventEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.CandidateSandboxId, y => y.MapFrom(x => x.CandidateSandboxId))
                   .ForMember(x => x.CalendarEventId, y => y.MapFrom(x => x.CalendarEventId))
                   .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                   .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InterviewEventEntityModel, InterviewEventDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.CandidateSandboxId, y => y.MapFrom(x => x.CandidateSandboxId))
                    .ForMember(x => x.CalendarEventId, y => y.MapFrom(x => x.CalendarEventId))
                    .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                    .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));

            return new Mapper(config);
        }
    }
}
