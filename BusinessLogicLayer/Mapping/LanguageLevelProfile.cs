using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public class LanguageLevelProfile
    {
        public LanguageLevelEntityModel mapToEM(LanguageLevelDtoModel languagelevelDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageLevelDtoModel, LanguageLevelEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LanguageLevelEntityModel languagelevelEM = mapper.Map<LanguageLevelDtoModel, LanguageLevelEntityModel>(languagelevelDto);
            return languagelevelEM;
        }

        public LanguageLevelDtoModel mapToDto(LanguageLevelEntityModel languagelevelEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageLevelEntityModel, LanguageLevelDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LanguageLevelDtoModel languagelevelDto = mapper.Map<LanguageLevelEntityModel, LanguageLevelDtoModel>(languagelevelEM);
            return languagelevelDto;
        }
        public IEnumerable<LanguageLevelDtoModel> mapListToDto(IEnumerable<LanguageLevelEntityModel> languagelevelsEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageLevelEntityModel, LanguageLevelDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<LanguageLevelDtoModel> languagelevelsDto = new List<LanguageLevelDtoModel>()
            {
                mapper.Map<LanguageLevelEntityModel, LanguageLevelDtoModel>(languagelevelsEM.FirstOrDefault())
            };

            int i = 0;
            foreach (var langlev in languagelevelsEM)
            {
                if (i != 0)
                {
                    LanguageLevelDtoModel languagelevelDto = mapper.Map<LanguageLevelEntityModel, LanguageLevelDtoModel>(langlev);
                    languagelevelsDto.Add(languagelevelDto);
                }
                i++;
            }
            return languagelevelsDto;
        }
    }
}
