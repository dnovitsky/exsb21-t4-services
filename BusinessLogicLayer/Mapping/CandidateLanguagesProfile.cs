using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class CandidateLanguagesProfile : BaseProfile<CandidateLanguageDtoModel, CandidateLanguageEntityModel>
    {
        private readonly LanguageLevelProfile langiageLevelProfile = new LanguageLevelProfile();
        private readonly LanguageProfile languageProfile = new LanguageProfile();
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateLanguageDtoModel, CandidateLanguageEntityModel>()
                    .ForMember(x => x.Language, y => y.MapFrom(x => x.Language))
                    .ForMember(x => x.LanguageLevel, y => y.MapFrom(x => x.LanguageLevel)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateLanguageEntityModel, CandidateLanguageDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Language, y => y.MapFrom(x => languageProfile.mapToDto(x.Language)))
                    .ForMember(x => x.LanguageLevel, y => y.MapFrom(x => langiageLevelProfile.mapToDto(x.LanguageLevel))));

            return new Mapper(config);
        }
    }
}
