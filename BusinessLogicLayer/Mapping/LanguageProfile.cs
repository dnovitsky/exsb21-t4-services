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
    public class LanguageProfile : Profile
    {
        public LanguageEntityModel mapToEM(LanguageDtoModel languageDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageDtoModel, LanguageEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            LanguageEntityModel language = mapper.Map<LanguageDtoModel, LanguageEntityModel>(languageDto);
            return language;
        }

        public LanguageDtoModel mapToDto(LanguageEntityModel languageEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageEntityModel, LanguageDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            LanguageDtoModel language = mapper.Map<LanguageEntityModel, LanguageDtoModel>(languageEM);
            return language;
        }

        public IEnumerable<LanguageDtoModel> mapListToDto(IEnumerable<LanguageEntityModel> languagesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageEntityModel, LanguageDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<LanguageDtoModel> languagesDto = new List<LanguageDtoModel>() { mapper.Map<LanguageEntityModel, LanguageDtoModel>(languagesEM.FirstOrDefault()) };
            int i = 0;
            foreach (var sand in languagesEM)
            {
                if (i != 0)
                {
                    LanguageDtoModel languageDto = mapper.Map<LanguageEntityModel, LanguageDtoModel>(sand);
                    languagesDto.Add(languageDto);
                }
                i++;
            }
            return languagesDto;
        }
    }
}
