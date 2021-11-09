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
        public AvailabilityEntityModel mapToEM(AvailabilityDtoModel availabilityDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityDtoModel, AvailabilityEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            AvailabilityEntityModel availabilityEM = mapper.Map<AvailabilityDtoModel, AvailabilityEntityModel>(availabilityDto);
            return availabilityEM;
        }

        public AvailabilityDtoModel mapToDto(AvailabilityEntityModel availabilityEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityEntityModel, AvailabilityDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            AvailabilityDtoModel availabilityDto = mapper.Map<AvailabilityEntityModel, AvailabilityDtoModel>(availabilityEM);
            return availabilityDto;
        }

        public IEnumerable<AvailabilityDtoModel> mapListToDto(IEnumerable<AvailabilityEntityModel> availabilitiesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityEntityModel, AvailabilityDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<AvailabilityDtoModel> availabilitiesDto= new List<AvailabilityDtoModel>() { mapper.Map<AvailabilityEntityModel, AvailabilityDtoModel>(availabilitiesEM.FirstOrDefault()) };
            int i = 0;
            foreach (var avail in availabilitiesEM)
            {
                if (i != 0)
                {
                    AvailabilityDtoModel availabilityDto = mapper.Map<AvailabilityEntityModel, AvailabilityDtoModel>(avail);
                    availabilitiesDto.Add(availabilityDto);
                }
                i++;
            }
            return availabilitiesDto;
        }
    }
}
