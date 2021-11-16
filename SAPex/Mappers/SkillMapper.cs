using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class SkillMapper : Profile
    {
        public SkillViewModel MapSkillFromDtoToView(SkillDtoModel skillDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillDtoModel, SkillViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            SkillViewModel skillVM = mapper.Map<SkillDtoModel, SkillViewModel>(skillDto);
            return skillVM;
        }

        public SkillDtoModel MapSkillFromViewToDto(SkillViewModel skillVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillViewModel, SkillDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            SkillDtoModel skillDto = mapper.Map<SkillViewModel, SkillDtoModel>(skillVM);
            return skillDto;
        }

        public IEnumerable<SkillViewModel> MapListSkillFromDtoToView(IEnumerable<SkillDtoModel> skillsDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillDtoModel, SkillViewModel>()
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<SkillViewModel> skillsVM = new List<SkillViewModel>();

            foreach (var skill in skillsDto)
            {
                    SkillViewModel skillVM = mapper.Map<SkillDtoModel, SkillViewModel>(skill);
                    skillsVM.Add(skillVM);
            }

            return skillsVM;
        }
    }
}
