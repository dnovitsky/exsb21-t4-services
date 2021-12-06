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
    public class AppSettingMapper : BaseMapper<AppSettingDtoModel, AppSettingViewModel>
    {
        protected override Mapper ViewToDtoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AppSettingViewModel, AppSettingDtoModel>()
                  .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Value, y => y.MapFrom(x => x.Value)));

            return new Mapper(config);
        }

        protected override Mapper DtoToViewMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AppSettingDtoModel, AppSettingViewModel>()
                  .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Value, y => y.MapFrom(x => x.Value)));

            return new Mapper(config);
        }
    }
}
