using System;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Mappers.Base;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class CreateCalendarEventMapper : BaseMapper<CalendarEventDtoModel, CreateCalendarEventViewModel>
    {
        protected override Mapper ViewToDtoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCalendarEventViewModel, CalendarEventDtoModel>()
                   .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                   .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));
            return new Mapper(config);
        }

        protected override Mapper DtoToViewMapper()
        {
            throw new NotImplementedException();
        }
    }
}
