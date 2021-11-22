using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class FilterParametrsMapper : Profile
    {
        public FilterParametrsDtoModel MapFromViewToDto(FilterParametrsViewModel filterParametrsView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilterParametrsViewModel, FilterParametrsDtoModel>()
                    .ForMember(x => x.FirstSearchingTextField, y => y.MapFrom(x => x.FirstSearchingTextField))
                    .ForMember(x => x.FirstSearchingTextString, y => y.MapFrom(x => x.FirstSearchingTextString))
                    .ForMember(x => x.SecondSearchingTextField, y => y.MapFrom(x => x.SecondSearchingTextField))
                    .ForMember(x => x.SecondSearchingTextString, y => y.MapFrom(x => x.SecondSearchingTextString))
                    .ForMember(x => x.SearchingDateField, y => y.MapFrom(x => x.SearchingDateField))
                    .ForMember(x => x.SearchingStatus, y => y.MapFrom(x => x.SearchingStatus))
                    .ForMember(x => x.SearchingDateString, y => y.MapFrom(x => x.SearchingDateString)));

            var mapper = new Mapper(config);

            FilterParametrsDtoModel filterParametrsDto = mapper.Map<FilterParametrsViewModel, FilterParametrsDtoModel>(filterParametrsView);
            return filterParametrsDto;
        }
    }
}
