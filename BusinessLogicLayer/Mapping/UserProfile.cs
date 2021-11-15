using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping.BaseMappings;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Mapping
{
    public class UserProfile : BaseProfile<UserDtoModel, UserEntityModel>
    {
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, UserEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                   .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                   .ForMember(x => x.Location, y => y.MapFrom(x => x.Location)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserEntityModel, UserDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Roles, y => y.MapFrom(x => (from userRole in x.UserRoles
                                                                  select userRole.FunctionalRole.Name).ToList())));

            return new Mapper(config);
        }
    }
}

