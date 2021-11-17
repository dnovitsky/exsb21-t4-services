using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CalendarEventProfile : BaseProfile<CalendarEventDtoModel, CalendarEventEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CalendarEventDtoModel, CalendarEventEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.InterviewerId, y => y.MapFrom(x => x.InterviewerId))
                   .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                   .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CalendarEventEntityModel, CalendarEventDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.InterviewerId, y => y.MapFrom(x => x.InterviewerId))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.User.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.User.Surname))
                    .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                    .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));

            return new Mapper(config);
        }
    }
}
