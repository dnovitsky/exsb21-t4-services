using System;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using SAPex.Models.EventModels;

namespace SAPex.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventEntityModel, EventDtoModel>();
            CreateMap<EventDtoModel, EventEntityModel>();

            CreateMap<EventDtoModel, EventViewModel>();
            CreateMap<EventViewModel, EventDtoModel>();

            CreateMap<InterviewEventViewModel, EventDtoModel>();
            CreateMap<EventDtoModel, InterviewEventViewModel>();

            CreateMap<CreateEventViewModel, EventDtoModel>();
            CreateMap<CreateInterviewEventViewModel, EventDtoModel>();
        }
    }
}
