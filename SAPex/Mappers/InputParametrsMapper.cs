using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class InputParametrsMapper : Profile
    {
        public InputParametrsDtoModel MapFromViewToDto(InputParametrsViewModel inputParametrsView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InputParametrsViewModel, InputParametrsDtoModel>()
                    .ForMember(x => x.PageNumber, y => y.MapFrom(x => x.PageNumber))
                    .ForMember(x => x.PageSize, y => y.MapFrom(x => x.PageSize))
                    .ForMember(x => x.SearchingString, y => y.MapFrom(x => x.SearchingString))
                    .ForMember(x => x.SortField, y => y.MapFrom(x => x.SortField))
                    .ForMember(x => x.SortType, y => y.MapFrom(x => x.SortType)));

            var mapper = new Mapper(config);

            InputParametrsDtoModel inputParametrsDto = mapper.Map<InputParametrsViewModel, InputParametrsDtoModel>(inputParametrsView);
            return inputParametrsDto;
        }
    }
}
