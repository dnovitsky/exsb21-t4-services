using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace BusinessLogicLayer.Mapping
{
    public class SandboxStackTechnologyProfile
    {
        public SandboxStackTechnologyEntityModel mapToEM(SandboxStackTechnologyDtoModel sandboxStackTechnologyDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxStackTechnologyDtoModel, SandboxStackTechnologyEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))
                    .ForMember(x => x.StackTechnologyId, y => y.MapFrom(x => x.StackTechnologyId)));

            var mapper = new Mapper(config);

            SandboxStackTechnologyEntityModel sandboxStackTechnologyEM = mapper.Map<SandboxStackTechnologyDtoModel, SandboxStackTechnologyEntityModel>(sandboxStackTechnologyDto);
            return sandboxStackTechnologyEM;
        }
    }
}
