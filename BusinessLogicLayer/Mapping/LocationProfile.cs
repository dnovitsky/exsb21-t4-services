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
    public class LocationProfile
    {
        public LocationEntityModel mapToEM(LocationDtoModel locationDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationDtoModel, LocationEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LocationEntityModel location = mapper.Map<LocationDtoModel, LocationEntityModel>(locationDto);
            return location;
        }

        public LocationDtoModel mapToDto(LocationEntityModel locationEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationEntityModel, LocationDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            LocationDtoModel location = mapper.Map<LocationEntityModel, LocationDtoModel>(locationEM);
            return location;
        }

        public IEnumerable<LocationDtoModel> mapListToDto(IEnumerable<LocationEntityModel> locationsEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationEntityModel, LocationDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<LocationDtoModel> locationsDto = new List<LocationDtoModel>() { mapper.Map<LocationEntityModel, LocationDtoModel>(locationsEM.FirstOrDefault()) };
            int i = 0;
            foreach (var location in locationsEM)
            {
                if (i != 0)
                {
                    LocationDtoModel locationDto = mapper.Map<LocationEntityModel, LocationDtoModel>(location);
                    locationsDto.Add(locationDto);
                }
                i++;
            }
            return locationsDto;
        }
    }
}
