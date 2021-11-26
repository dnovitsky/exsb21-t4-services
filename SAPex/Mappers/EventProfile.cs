using System;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using SAPex.Models.EventModels;
using SAPexGoogleSupportService.Models.Calendar;

namespace SAPex.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventEntityModel, EventDtoModel>();
            CreateMap<EventDtoModel, EventEntityModel>();

            CreateMap<EventDtoModel, EventViewModel>();
            CreateMap<EventViewModel, EventDtoModel>()
                 .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime.ToUniversalTime()))
                 .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime.ToUniversalTime()));

            CreateMap<InterviewEventViewModel, EventDtoModel>();
            CreateMap<EventDtoModel, InterviewEventViewModel>();

            CreateMap<CreateEventViewModel, EventDtoModel>();
            CreateMap<CreateInterviewEventViewModel, EventDtoModel>();

            CreateMap<InterviewMemberViewModel, InterviewMemberDtoModel>();
            CreateMap<InterviewMemberDtoModel, InterviewMemberViewModel>();
        }
    }
}
