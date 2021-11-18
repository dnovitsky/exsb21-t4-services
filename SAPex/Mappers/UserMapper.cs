using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class UserMapper : Profile
    {
        public UserViewModel MapUserFromDtoToView(UserDtoModel userDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, UserViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Roles, y => y.MapFrom(x => x.Roles)));
            var mapper = new Mapper(config);

            UserViewModel user = mapper.Map<UserDtoModel, UserViewModel>(userDto);
            return user;
        }

        public UserDtoModel MapUserFromVMToDto(UserViewModel userVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Roles, y => y.MapFrom(x => x.Roles)));
            var mapper = new Mapper(config);

            UserDtoModel user = mapper.Map<UserViewModel, UserDtoModel>(userVM);
            return user;
        }
    }
}
