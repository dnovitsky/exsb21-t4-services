using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateTechSkillProfile : BaseProfile<CandidateTechSkillDtoModel, CandidateTechSkillEntityModel>
    {
        private readonly SkillProfile skillProfile = new SkillProfile();

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateTechSkillDtoModel, CandidateTechSkillEntityModel>()
                    .ForMember(x => x.Skill, y => y.MapFrom(x => x.Skill)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateTechSkillEntityModel, CandidateTechSkillDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Skill, y => y.MapFrom(x => skillProfile.mapToDto(x.Skill) )));

            return new Mapper(config);
        }
    }
}
