using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace BusinessLogicLayer.Mapping
{
    public class SkillProfile
    {
        public SkillEntityModel mapToEM(SkillDtoModel skillDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillDtoModel, SkillEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            SkillEntityModel skillEM = mapper.Map<SkillDtoModel, SkillEntityModel>(skillDto);
            return skillEM;
        }

        public SkillDtoModel mapToDto(SkillEntityModel skillEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillEntityModel, SkillDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            SkillDtoModel skillDto= mapper.Map<SkillEntityModel,SkillDtoModel>(skillEM);
            return skillDto;
        }

        public IEnumerable<SkillDtoModel> mapListToDto(IEnumerable<SkillEntityModel> skillsEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillEntityModel, SkillDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));
            var mapper = new Mapper(config);

            IList<SkillDtoModel> skillsDto = new List<SkillDtoModel>() 
            { 
                mapper.Map<SkillEntityModel, SkillDtoModel>(skillsEM.FirstOrDefault()) 
            };
            int i = 0;
            foreach (var skill in skillsEM)
            {
                if (i != 0)
                {
                    SkillDtoModel skillDto = mapper.Map<SkillEntityModel, SkillDtoModel>(skill);
                    skillsDto.Add(skillDto);
                }
                i++;
            }
            return skillsDto;
        }
    }
}
