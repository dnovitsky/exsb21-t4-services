using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class StatusMapper : Profile
    {
        public StatusViewModel MapDtoToView(StatusDtoModel statusDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusDtoModel, StatusViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            StatusViewModel status = mapper.Map<StatusDtoModel, StatusViewModel>(statusDM);
            return status;
        }

        public StatusDtoModel MaToDto(StatusViewModel statusVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusViewModel, StatusDtoModel>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            StatusDtoModel status = mapper.Map<StatusViewModel, StatusDtoModel>(statusVM);
            return status;
        }

        public IEnumerable<StatusViewModel> MapListToView(IEnumerable<StatusDtoModel> statusesVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusDtoModel, StatusViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<StatusViewModel> statusViewList = new List<StatusViewModel>() { };
            int i = 0;
            foreach (var status in statusesVM)
            {
                StatusViewModel statusVM = mapper.Map<StatusDtoModel, StatusViewModel>(status);
                statusViewList.Add(statusVM);
            }

            return statusViewList;
        }
    }
}
