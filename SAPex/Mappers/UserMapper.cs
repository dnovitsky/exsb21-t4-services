using System.Collections.Generic;
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

        public string MapListUserFromDtoToString(IEnumerable<UserDtoModel> usersDto)
        {
            string usersString = string.Empty;

            foreach (var user in usersDto)
            {
                if (user != null)
                {
                    usersString += user.Name + " " + user.Surname + ", " + user.Email + '\n';
                }
            }

            if (usersString != string.Empty)
            {
                usersString = usersString.Remove(usersString.LastIndexOf('\n'));
            }

            return usersString;
        }
    }
}
