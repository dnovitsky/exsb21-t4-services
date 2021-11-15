using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class SandboxStackTechnologyMapper
    {
        public IEnumerable<SandboxStackTechnologyDtoModel> MapListSBSTFromVMToDto(IEnumerable<SandboxStackTechnologyViewModel> sandboxStackTechnologiesVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxStackTechnologyViewModel, SandboxStackTechnologyDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))
                   .ForMember(x => x.StackTechnologyId, y => y.MapFrom(x => x.StackTechnologyId)));
            var mapper = new Mapper(config);

            IList<SandboxStackTechnologyDtoModel> sandboxStackTechnologiesDto = new List<SandboxStackTechnologyDtoModel>();
            foreach (var sand in sandboxStackTechnologiesVM)
            {
                SandboxStackTechnologyDtoModel sandbox = mapper.Map<SandboxStackTechnologyViewModel, SandboxStackTechnologyDtoModel>(sand);
                sandboxStackTechnologiesDto.Add(sandbox);
            }

            return sandboxStackTechnologiesDto;
        }
    }
}
