using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateProjectRoleProfile : BaseProfile<CandidateProjectRoleDtoModel, CandidateProjectRoleEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProjectRoleDtoModel, CandidateProjectRoleEntityModel>()
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProjectRoleEntityModel, CandidateProjectRoleDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            return new Mapper(config);
        }
    }
}
