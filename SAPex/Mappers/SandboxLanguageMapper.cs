using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class SandboxLanguageMapper
    {
        public IEnumerable<SandboxLanguageDtoModel> MapListSBLFromVMToDto(IEnumerable<SandboxLanguageViewModel> sandboxLanguageVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxLanguageViewModel, SandboxLanguageDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId))
                   .ForMember(x => x.LanguageId, y => y.MapFrom(x => x.LanguageId)));
            var mapper = new Mapper(config);

            IList<SandboxLanguageDtoModel> sandboxLanguagesDto = new List<SandboxLanguageDtoModel>();
            foreach (var sand in sandboxLanguageVM)
            {
                SandboxLanguageDtoModel sandbox = mapper.Map<SandboxLanguageViewModel, SandboxLanguageDtoModel>(sand);
                sandboxLanguagesDto.Add(sandbox);
            }

            return sandboxLanguagesDto;
        }
    }
}
