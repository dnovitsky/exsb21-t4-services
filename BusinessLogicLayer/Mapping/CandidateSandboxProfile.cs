using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateSandboxProfile : BaseProfile<CandidateSandboxDtoModel, CandidateSandboxEntityModel>
    {
        private readonly SandboxProfile sandboxProfile = new SandboxProfile();
        private readonly CandidateProjectRoleProfile candidateProjectRoleProfile = new CandidateProjectRoleProfile();
        private readonly CandidateProcessProfile candidateProcessProfile = new CandidateProcessProfile();

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateSandboxDtoModel, CandidateSandboxEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Sandbox, y => y.MapFrom(x => x.Sandbox))
                    .ForMember(x => x.CandidateProjectRole, y => y.MapFrom(x => x.CandidateProjectRole)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateSandboxEntityModel, CandidateSandboxDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Sandbox, y => y.MapFrom(x => sandboxProfile.mapToDto(x.Sandbox)))
                    .ForMember(x => x.CandidateProcesses, y => y.MapFrom(x => candidateProcessProfile.mapListToDto(x.CandidateProcesses)))
                    .ForMember(x => x.CandidateProjectRole, y => y.MapFrom(x => candidateProjectRoleProfile.mapToDto(x.CandidateProjectRole))));

            return new Mapper(config);
        }
    }
}
