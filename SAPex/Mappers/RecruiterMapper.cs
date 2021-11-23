using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class RecruiterMapper
    {
        public RecruiterViewModel MapRecruiterFromDtoToView(UserDtoModel userDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, RecruiterViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location)));
            var mapper = new Mapper(config);

            RecruiterViewModel recruiter = mapper.Map<UserDtoModel, RecruiterViewModel>(userDto);
            return recruiter;
        }

        public IEnumerable<RecruiterViewModel> MapRecruiterListFromDtoToView(IEnumerable<UserDtoModel> userDtos)
        {
            IList<RecruiterViewModel> recruiterViewModels = new List<RecruiterViewModel>();

            foreach (var dto in userDtos)
            {
                recruiterViewModels.Add(MapRecruiterFromDtoToView(dto));
            }

            return recruiterViewModels;
        }
    }
}
