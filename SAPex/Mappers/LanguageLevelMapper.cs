using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class LanguageLevelMapper
    {
        public LanguageLevelDtoModel MapToDto(LanguageLevelViewModel languagelevelVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageLevelViewModel, LanguageLevelDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.OrderLevel, y => y.MapFrom(x => x.OrderLevel)));

            var mapper = new Mapper(config);

            LanguageLevelDtoModel languagelevelDto = mapper.Map<LanguageLevelViewModel, LanguageLevelDtoModel>(languagelevelVM);
            return languagelevelDto;
        }

        public LanguageLevelViewModel MapToVM(LanguageLevelDtoModel languagelevelDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageLevelDtoModel, LanguageLevelViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.OrderLevel, y => y.MapFrom(x => x.OrderLevel)));

            var mapper = new Mapper(config);

            LanguageLevelViewModel languagelevelVM = mapper.Map<LanguageLevelDtoModel, LanguageLevelViewModel>(languagelevelDto);
            return languagelevelVM;
        }

        public IEnumerable<LanguageLevelViewModel> MapListToVM(IEnumerable<LanguageLevelDtoModel> languagelevelsDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LanguageLevelDtoModel, LanguageLevelDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.OrderLevel, y => y.MapFrom(x => x.OrderLevel)));

            var mapper = new Mapper(config);

            IList<LanguageLevelViewModel> languagelevelsVM = new List<LanguageLevelViewModel>() { };

            foreach (var langlev in languagelevelsDto)
            {
                LanguageLevelViewModel languagelevelVM = mapper.Map<LanguageLevelDtoModel, LanguageLevelViewModel>(langlev);
                languagelevelsVM.Add(languagelevelVM);
            }

            return languagelevelsVM;
        }
    }
}
