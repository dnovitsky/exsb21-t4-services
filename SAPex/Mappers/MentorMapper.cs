using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class MentorMapper
    {
        public MentorViewModel MapMentorFromDtoToView(UserDtoModel userDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, MentorViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location)));
            var mapper = new Mapper(config);

            MentorViewModel mentor = mapper.Map<UserDtoModel, MentorViewModel>(userDto);
            return mentor;
        }

        public IEnumerable<MentorViewModel> MapMentorListFromDtoToView(IEnumerable<UserDtoModel> userDtos)
        {
            IList<MentorViewModel> mentorViewModels = new List<MentorViewModel>();

            foreach (var dto in userDtos)
            {
                mentorViewModels.Add(MapMentorFromDtoToView(dto));
            }

            return mentorViewModels;
        }
    }
}
