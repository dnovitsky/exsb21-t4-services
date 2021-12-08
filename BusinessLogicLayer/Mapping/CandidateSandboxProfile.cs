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
        private readonly StackTechnologyProfile stackTechnologyProfile = new StackTechnologyProfile();

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateSandboxDtoModel, CandidateSandboxEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))

                    .ForMember(x => x.Motivation, y => y.MapFrom(x => x.Motivation))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.TimeContact, y => y.MapFrom(x => x.TimeContact))
                    .ForMember(x => x.IsJoinToExadel, y => y.MapFrom(x => x.IsJoinToExadel))
                    .ForMember(x => x.IsAgreement, y => y.MapFrom(x => x.IsAgreement))
                    .ForMember(x => x.StackTechnology, y => y.MapFrom(x => stackTechnologyProfile.mapToEM(x.PrimaryTechnology)))

                    .ForMember(x => x.Sandbox, y => y.MapFrom(x => x.Sandbox))
                    .ForMember(x => x.CandidateProjectRole, y => y.MapFrom(x => x.CandidateProjectRole))
                    .ForMember(x => x.CandidateProcesses, y => y.MapFrom(x => x.CandidateProcesses)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateSandboxEntityModel, CandidateSandboxDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))

                    .ForMember(x => x.Motivation, y => y.MapFrom(x => x.Motivation))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.TimeContact, y => y.MapFrom(x => x.TimeContact))
                    .ForMember(x => x.IsJoinToExadel, y => y.MapFrom(x => x.IsJoinToExadel))
                    .ForMember(x => x.IsAgreement, y => y.MapFrom(x => x.IsAgreement))
                    .ForMember(x => x.PrimaryTechnology, y => y.MapFrom(x => stackTechnologyProfile.mapToDto(x.StackTechnology)))

                    .ForMember(x => x.Sandbox, y => y.MapFrom(x => sandboxProfile.mapToDto(x.Sandbox)))
                    .ForMember(x => x.CandidateProjectRole, y => y.MapFrom(x => candidateProjectRoleProfile.mapToDto(x.CandidateProjectRole)))
                    .ForMember(x => x.CandidateProcesses, y => y.MapFrom(x => candidateProcessProfile.mapListToDto(x.CandidateProcesses))));

            return new Mapper(config);
        }
    }
}
