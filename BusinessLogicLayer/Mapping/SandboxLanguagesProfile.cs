using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace BusinessLogicLayer.Mapping
{
    public class SandboxLanguagesProfile
    {
        public SandboxLanguageEntityModel mapToEM(SandboxLanguageDtoModel sandboxLanguageDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxLanguageDtoModel, SandboxLanguageEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))
                    .ForMember(x => x.LanguageId, y => y.MapFrom(x => x.LanguageId)));

            var mapper = new Mapper(config);

            SandboxLanguageEntityModel sandboxLanguageEM = mapper.Map<SandboxLanguageDtoModel, SandboxLanguageEntityModel>(sandboxLanguageDto);
            return sandboxLanguageEM;
        }
    }
}
