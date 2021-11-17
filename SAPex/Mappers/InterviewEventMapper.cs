using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers.Base;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class InterviewEventMapper : BaseMapper<InterviewEventDtoModel, InterviewEventViewModel>
    {
        protected override Mapper DtoToViewMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InterviewEventDtoModel, InterviewEventViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.CandidateSandboxId, y => y.MapFrom(x => x.CandidateSandboxId))
                    .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                    .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));

            return new Mapper(config);
        }

        protected override Mapper ViewToDtoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateInterviewEventViewModel, InterviewEventDtoModel>()
                    .ForMember(x => x.CalendarEventId, y => y.MapFrom(x => x.CalendarEventId))
                    .ForMember(x => x.CandidateSandboxId, y => y.MapFrom(x => x.CandidateSandboxId))
                    .ForMember(x => x.StartTime, y => y.MapFrom(x => x.StartTime))
                    .ForMember(x => x.EndTime, y => y.MapFrom(x => x.EndTime)));
            return new Mapper(config);
        }
    }
}
