using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Mappers.Base;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class CalendarEventMapper : BaseMapper<CalendarEventDtoModel, CalendarEventViewModel>
    {
        protected override Mapper DtoToViewMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CalendarEventDtoModel, CalendarEventViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.InterviewerId, y => y.MapFrom(x => x.InterviewerId))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                    .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));
            return new Mapper(config);
        }

        protected override Mapper ViewToDtoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CalendarEventViewModel, CalendarEventDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                    .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime))
                    .ForMember(x => x.InterviewerId, y => y.MapFrom(x => x.InterviewerId)));
            return new Mapper(config);
        }
    }
}
