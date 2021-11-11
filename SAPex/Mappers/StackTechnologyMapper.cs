using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class StackTechnologyMapper : Profile
    {
        public StackTechnologyViewModel MapStackTechnologyFromDtoToView(StackTechnologyDtoModel stackTechnologyDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackTechnologyDtoModel, StackTechnologyViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            StackTechnologyViewModel stackTechnology = mapper.Map<StackTechnologyDtoModel, StackTechnologyViewModel>(stackTechnologyDto);
            return stackTechnology;
        }

        public StackTechnologyDtoModel MapStackTechnologyFromViewToDto(StackTechnologyViewModel stackTechnologyView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackTechnologyViewModel, StackTechnologyDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            StackTechnologyDtoModel stackTechnology = mapper.Map<StackTechnologyViewModel, StackTechnologyDtoModel>(stackTechnologyView);
            return stackTechnology;
        }

        public IEnumerable<StackTechnologyViewModel> MapListStackTechnologyFromDtoToView(IEnumerable<StackTechnologyDtoModel> stackTechnologiesDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StackTechnologyDtoModel, StackTechnologyViewModel>()
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<StackTechnologyViewModel> stackTechnologyViewList = new List<StackTechnologyViewModel>()
            {
                mapper.Map<StackTechnologyDtoModel, StackTechnologyViewModel>(stackTechnologiesDto.FirstOrDefault()),
            };
            int i = 0;
            foreach (var sand in stackTechnologiesDto)
            {
                if (i != 0)
                {
                    StackTechnologyViewModel stackTechnology = mapper.Map<StackTechnologyDtoModel, StackTechnologyViewModel>(sand);
                    stackTechnologyViewList.Add(stackTechnology);
                }

                i++;
            }

            return stackTechnologyViewList;
        }
    }
}
