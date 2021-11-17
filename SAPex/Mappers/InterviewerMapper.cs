using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class InterviewerMapper
    {
        public InterviewerViewModel MapInterviewerFromDtoToView(UserDtoModel userDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDtoModel, InterviewerViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location)));
            var mapper = new Mapper(config);

            InterviewerViewModel interviewer = mapper.Map<UserDtoModel, InterviewerViewModel>(userDto);
            return interviewer;
        }
    }
}
