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
    public class StackTechnologyProfile : Profile
    {
        public StackTechnologyEntityModel mapToEM(StackTechnologyDtoModel stackTechnologyDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackTechnologyDtoModel, StackTechnologyEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            StackTechnologyEntityModel stackTechnology = mapper.Map<StackTechnologyDtoModel, StackTechnologyEntityModel>(stackTechnologyDto);
            return stackTechnology;
        }

        public StackTechnologyDtoModel mapToDto(StackTechnologyEntityModel StackTechnologyEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackTechnologyEntityModel, StackTechnologyDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            StackTechnologyDtoModel StackTechnology = mapper.Map<StackTechnologyEntityModel, StackTechnologyDtoModel>(StackTechnologyEM);
            return StackTechnology;
        }

        public IEnumerable<StackTechnologyDtoModel> mapListToDto(IEnumerable<StackTechnologyEntityModel> StackTechnologiesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackTechnologyEntityModel, StackTechnologyDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<StackTechnologyDtoModel> StackTechnologiesDto = new List<StackTechnologyDtoModel>() { mapper.Map<StackTechnologyEntityModel, StackTechnologyDtoModel>(StackTechnologiesEM.FirstOrDefault()) };
            int i = 0;
            foreach (var sand in StackTechnologiesEM)
            {
                if (i != 0)
                {
                    StackTechnologyDtoModel StackTechnologyDto = mapper.Map<StackTechnologyEntityModel, StackTechnologyDtoModel>(sand);
                    StackTechnologiesDto.Add(StackTechnologyDto);
                }
                i++;
            }
            return StackTechnologiesDto;
        }
    }
}
