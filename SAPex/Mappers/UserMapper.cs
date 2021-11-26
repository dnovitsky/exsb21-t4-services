using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDtoModel, UserViewModel>();
            CreateMap<UserViewModel, UserDtoModel>();
        }
    }
}
