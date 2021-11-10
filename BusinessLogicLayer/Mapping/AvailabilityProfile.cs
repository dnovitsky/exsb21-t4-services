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
    public class AvailabilityProfile
    {
        public AvailabilityTypeEntityModel mapToEM(AvailabilityTypeDtoModel availabilityDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityTypeDtoModel, AvailabilityTypeEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.OrderLevel, y => y.MapFrom(x => x.OrderLevel)));

            var mapper = new Mapper(config);

            AvailabilityTypeEntityModel availabilityEM = mapper.Map<AvailabilityTypeDtoModel, AvailabilityTypeEntityModel>(availabilityDto);
            return availabilityEM;
        }

        public AvailabilityTypeDtoModel mapToDto(AvailabilityTypeEntityModel availabilityEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityTypeEntityModel, AvailabilityTypeDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.OrderLevel, y => y.MapFrom(x => x.OrderLevel)));

            var mapper = new Mapper(config);

            AvailabilityTypeDtoModel availabilityDto = mapper.Map<AvailabilityTypeEntityModel, AvailabilityTypeDtoModel>(availabilityEM);
            return availabilityDto;
        }

        public IEnumerable<AvailabilityTypeDtoModel> mapListToDto(IEnumerable<AvailabilityTypeEntityModel> availabilitiesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityTypeEntityModel, AvailabilityTypeDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.OrderLevel, y => y.MapFrom(x => x.OrderLevel)));

            var mapper = new Mapper(config);

            IList<AvailabilityTypeDtoModel> availabilitiesDto= new List<AvailabilityTypeDtoModel>()
            {
                mapper.Map<AvailabilityTypeEntityModel, AvailabilityTypeDtoModel>(availabilitiesEM.FirstOrDefault())
            };

            int i = 0;
            foreach (var avail in availabilitiesEM)
            {
                if (i != 0)
                {
                    AvailabilityTypeDtoModel availabilityDto = mapper.Map<AvailabilityTypeEntityModel, AvailabilityTypeDtoModel>(avail);
                    availabilitiesDto.Add(availabilityDto);
                }
                i++;
            }
            return availabilitiesDto;
        }
    }
}
