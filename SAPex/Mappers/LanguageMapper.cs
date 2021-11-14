using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class LanguageMapper : Profile
    {
        public LanguageViewModel MapLanguageFromDtoToView(LanguageDtoModel languageDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageDtoModel, LanguageViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LanguageViewModel language = mapper.Map<LanguageDtoModel, LanguageViewModel>(languageDto);
            return language;
        }

        public LanguageDtoModel MapLanguageFromViewToDto(LanguageViewModel languageView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageViewModel, LanguageDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LanguageDtoModel language = mapper.Map<LanguageViewModel, LanguageDtoModel>(languageView);
            return language;
        }

        public IEnumerable<LanguageViewModel> MapListLanguageFromDtoToView(IEnumerable<LanguageDtoModel> languagesDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageDtoModel, LanguageViewModel>()
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<LanguageViewModel> languageViewList = new List<LanguageViewModel>()
            {
                mapper.Map<LanguageDtoModel, LanguageViewModel>(languagesDto.FirstOrDefault()),
            };
            int i = 0;
            foreach (var sand in languagesDto)
            {
                if (i != 0)
                {
                    LanguageViewModel language = mapper.Map<LanguageDtoModel, LanguageViewModel>(sand);
                    languageViewList.Add(language);
                }

                i++;
            }

            return languageViewList;
        }
    }
}
