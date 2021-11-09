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
        public AvailabilityTypeEntityModel mapToEM(AvailabilityDtoModel availabilityDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityDtoModel, AvailabilityTypeEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            AvailabilityTypeEntityModel availabilityEM = mapper.Map<AvailabilityDtoModel, AvailabilityTypeEntityModel>(availabilityDto);
            return availabilityEM;
        }

        public AvailabilityDtoModel mapToDto(AvailabilityTypeEntityModel availabilityEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityTypeEntityModel, AvailabilityDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            AvailabilityDtoModel availabilityDto = mapper.Map<AvailabilityTypeEntityModel, AvailabilityDtoModel>(availabilityEM);
            return availabilityDto;
        }

        public IEnumerable<AvailabilityDtoModel> mapListToDto(IEnumerable<AvailabilityTypeEntityModel> availabilitiesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AvailabilityTypeEntityModel, AvailabilityDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<AvailabilityDtoModel> availabilitiesDto= new List<AvailabilityDtoModel>()
            {
                mapper.Map<AvailabilityTypeEntityModel, AvailabilityDtoModel>(availabilitiesEM.FirstOrDefault())
            };

            int i = 0;
            foreach (var avail in availabilitiesEM)
            {
                if (i != 0)
                {
                    AvailabilityDtoModel availabilityDto = mapper.Map<AvailabilityTypeEntityModel, AvailabilityDtoModel>(avail);
                    availabilitiesDto.Add(availabilityDto);
                }
                i++;
            }
            return availabilitiesDto;
        }
    }
}
