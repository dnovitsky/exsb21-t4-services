using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Mapping
{
    public class UserSandboxProfile : Profile
    {
        public UserSandBoxEntityModel mapToEM(UserSandboxDtoModel userSandboxDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserSandboxDtoModel, UserSandBoxEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.SandBoxId, y => y.MapFrom(x => x.SandboxId))
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId)));

            var mapper = new Mapper(config);

            UserSandBoxEntityModel userSandBoxEM = mapper.Map<UserSandboxDtoModel, UserSandBoxEntityModel>(userSandboxDto);
            return userSandBoxEM;
        }
    }
}
