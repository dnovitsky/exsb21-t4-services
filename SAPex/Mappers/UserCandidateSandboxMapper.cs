using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Mappers.Base;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class UserCandidateSandboxMapper : BaseMapper<UserCandidateSandboxDtoModel, UserCandidateSandboxViewModel>
    {
        protected override Mapper ViewToDtoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserCandidateSandboxViewModel, UserCandidateSandboxDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.CandidateSandboxId, y => y.MapFrom(x => x.CandidateSandboxId)));

            return new Mapper(config);
        }

        protected override Mapper DtoToViewMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserCandidateSandboxDtoModel, UserCandidateSandboxViewModel>()
                  .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.CandidateSandboxId, y => y.MapFrom(x => x.CandidateSandboxId)));

            return new Mapper(config);
        }
    }
}
