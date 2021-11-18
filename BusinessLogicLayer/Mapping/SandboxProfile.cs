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
    public class SandboxProfile : Profile
    {
        public SandboxEntityModel mapToEM(SandboxDtoModel sandboxDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxEntityModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxEntityModel sandbox = mapper.Map<SandboxDtoModel, SandboxEntityModel>(sandboxDto);
            return sandbox;
        }

        public SandboxDtoModel mapToDto(SandboxEntityModel sandboxEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxEntityModel, SandboxDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxDtoModel sandbox = mapper.Map<SandboxEntityModel, SandboxDtoModel>(sandboxEM);
            return sandbox;
        }

        public IEnumerable<SandboxDtoModel> mapListToDto(IEnumerable<SandboxEntityModel> sandboxesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxEntityModel, SandboxDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);


            IList<SandboxDtoModel> sandboxDtoList = new List<SandboxDtoModel>()
            {
                mapper.Map<SandboxEntityModel, SandboxDtoModel>(sandboxesEM.FirstOrDefault())
            };
            int i = 0;
            foreach (var sand in sandboxesEM)
            {
                if (i != 0)
                {
                    SandboxDtoModel sandbox = mapper.Map<SandboxEntityModel, SandboxDtoModel>(sand);
                    sandboxDtoList.Add(sandbox);
                }
                i++;
            }
            return sandboxDtoList;
        }
    }
}
