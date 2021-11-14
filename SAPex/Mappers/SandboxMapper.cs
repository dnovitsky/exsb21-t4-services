using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class SandboxMapper : Profile
    {
        public SandboxViewModel MapSbFromDtoToView(SandboxDtoModel sandboxDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxViewModel>(sandboxDto);
            return sandbox;
        }

        public SandboxDtoModel MapSbFromViewToDto(SandboxViewModel sandboxView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxViewModel, SandboxDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxDtoModel sandbox = mapper.Map<SandboxViewModel, SandboxDtoModel>(sandboxView);
            return sandbox;
        }

        public IEnumerable<SandboxViewModel> MapListSbFromDtoToView(IEnumerable<SandboxDtoModel> sandboxesDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxViewModel>()
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                   .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                   .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                   .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                   .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                   .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                   .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            IList<SandboxViewModel> sandboxViewList = new List<SandboxViewModel>()
            {
                mapper.Map<SandboxDtoModel, SandboxViewModel>(sandboxesDto.FirstOrDefault()),
            };
            int i = 0;
            foreach (var sand in sandboxesDto)
            {
                if (i != 0)
                {
                    SandboxViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxViewModel>(sand);
                    sandboxViewList.Add(sandbox);
                }

                i++;
            }

            return sandboxViewList;
        }

        public SandboxViewModel MapSbStackLgFromDtoToView(
            SandboxDtoModel sandboxDto,
            IEnumerable<LanguageDtoModel> languagesDto,
            IEnumerable<StackTechnologyDtoModel> stackTechnologiesDto)
        {
            SandboxViewModel sandboxView = MapSbFromDtoToView(sandboxDto);

            sandboxView.Languages = new LanguageMapper().MapListLanguageFromDtoToView(languagesDto);
            sandboxView.StackTechnologies = new StackTechnologyMapper().MapListStackTechnologyFromDtoToView(stackTechnologiesDto);

            return sandboxView;
        }
    }
}
