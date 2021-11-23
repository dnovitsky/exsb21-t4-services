using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class LocationMapper : Profile
    {
        public LocationViewModel MapLocationFromDtoToView(LocationDtoModel locationDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationDtoModel, LocationViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LocationViewModel language = mapper.Map<LocationDtoModel, LocationViewModel>(locationDto);
            return language;
        }

        public LocationDtoModel MapLocationFromViewToDto(LocationViewModel locationView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationViewModel, LocationDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LocationDtoModel language = mapper.Map<LocationViewModel, LocationDtoModel>(locationView);
            return language;
        }

        public IEnumerable<LocationViewModel> MapListLocationFromDtoToView(IEnumerable<LocationDtoModel> locationsDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationDtoModel, LocationViewModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<LocationViewModel> locationViewList = new List<LocationViewModel>()
            {
                mapper.Map<LocationDtoModel, LocationViewModel>(locationsDto.FirstOrDefault()),
            };
            int i = 0;
            foreach (var location in locationsDto)
            {
                if (i != 0)
                {
                    LocationViewModel language = mapper.Map<LocationDtoModel, LocationViewModel>(location);
                    locationViewList.Add(language);
                }

                i++;
            }

            return locationViewList;
        }
    }
}
