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
    class InputParametrsProfile : Profile
    {
        public InputParametrsEntityModel MapFromDtoToEntity(InputParametrsDtoModel inputParametrsDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InputParametrsDtoModel, InputParametrsEntityModel>()
                    .ForMember(x => x.PageNumber, y => y.MapFrom(x => x.PageNumber))
                    .ForMember(x => x.PageSize, y => y.MapFrom(x => x.PageSize))
                    .ForMember(x => x.SortField, y => y.MapFrom(x => x.SortField))
                    .ForMember(x => x.SortingType, y => y.MapFrom(x => x.SortingType)));

            var mapper = new Mapper(config);

            InputParametrsEntityModel inputParametrsEntity = mapper.Map<InputParametrsDtoModel, InputParametrsEntityModel>(inputParametrsDto);
            return inputParametrsEntity;
        }
    }
}
