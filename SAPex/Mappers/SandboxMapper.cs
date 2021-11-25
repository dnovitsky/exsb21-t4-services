using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using Newtonsoft.Json;
using OfficeOpenXml;
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
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status.ToString()))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxViewModel>(sandboxDto);
            return sandbox;
        }

        public SandboxExcelViewModel MapSbFromDtoToViewExcel(SandboxDtoModel sandboxDto)
        {
            const string dateType = "d";

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxExcelViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate.ToString(dateType)))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate.ToString(dateType)))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate.ToString(dateType)))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration.ToString(dateType)))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status.ToString()))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration.ToString(dateType))));
            var mapper = new Mapper(config);

            SandboxExcelViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxExcelViewModel>(sandboxDto);

            return sandbox;
        }

        public SandboxDtoModel MapSbFromViewToDto(SandboxPostViewModel sandboxView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxPostViewModel, SandboxDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                    .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                    .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                    .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                    .ForMember(x => x.Status, y => y.MapFrom(x => (StatusName)Enum.Parse(typeof(StatusName), x.Status)))
                    .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxDtoModel sandbox = mapper.Map<SandboxPostViewModel, SandboxDtoModel>(sandboxView);
            return sandbox;
        }

        public SandboxDtoModel MapSbFromViewToDto(SandboxPutViewModel sandboxView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxPutViewModel, SandboxDtoModel>()
                     .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                     .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                     .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                     .ForMember(x => x.MaxCandidates, y => y.MapFrom(x => x.MaxCandidates))
                     .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                     .ForMember(x => x.StartDate, y => y.MapFrom(x => x.StartDate))
                     .ForMember(x => x.EndDate, y => y.MapFrom(x => x.EndDate))
                     .ForMember(x => x.StartRegistration, y => y.MapFrom(x => x.StartRegistration))
                     .ForMember(x => x.Status, y => y.MapFrom(x => (StatusName)Enum.Parse(typeof(StatusName), x.Status)))
                     .ForMember(x => x.EndRegistration, y => y.MapFrom(x => x.EndRegistration)));
            var mapper = new Mapper(config);

            SandboxDtoModel sandbox = mapper.Map<SandboxPutViewModel, SandboxDtoModel>(sandboxView);
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
                   .ForMember(x => x.Status, y => y.MapFrom(x => x.Status.ToString()))
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

        public SandboxViewModel MapFromDtoToView(
            SandboxDtoModel sandboxDto,
            IEnumerable<LanguageDtoModel> languagesDto,
            IEnumerable<StackTechnologyDtoModel> stackTechnologiesDto,
            IEnumerable<UserDtoModel> mentorDtoModels,
            IEnumerable<UserDtoModel> recruiterDtoModels,
            IEnumerable<UserDtoModel> interwieverDtoModels)
        {
            SandboxViewModel sandboxView = MapSbFromDtoToView(sandboxDto);

            sandboxView.Languages = new LanguageMapper().MapListLanguageFromDtoToView(languagesDto);
            sandboxView.StackTechnologies = new StackTechnologyMapper().MapListStackTechnologyFromDtoToView(stackTechnologiesDto);
            sandboxView.Mentors = new MentorMapper().MapMentorListFromDtoToView(mentorDtoModels);
            sandboxView.Recruiters = new RecruiterMapper().MapRecruiterListFromDtoToView(recruiterDtoModels);
            sandboxView.Interviewers = new InterviewerMapper().MapInterviewerListFromDtoToView(interwieverDtoModels);

            return sandboxView;
        }

        public SandboxExcelViewModel MapFromDtoToExcelView(
            SandboxDtoModel sandboxDto,
            IEnumerable<LanguageDtoModel> languagesDto,
            IEnumerable<StackTechnologyDtoModel> stackTechnologiesDto,
            IEnumerable<UserDtoModel> mentorDtoModels,
            IEnumerable<UserDtoModel> recruiterDtoModels,
            IEnumerable<UserDtoModel> interwieverDtoModels)
        {
            SandboxExcelViewModel sandboxView = MapSbFromDtoToViewExcel(sandboxDto);

            sandboxView.Languages = new LanguageMapper().MapListLanguageFromDtoToString(languagesDto);
            sandboxView.StackTechnologies = new StackTechnologyMapper().MapListStackTechnologyFromDtoToString(stackTechnologiesDto);
            sandboxView.Mentors = new UserMapper().MapListUserFromDtoToString(mentorDtoModels);
            sandboxView.Recruiters = new UserMapper().MapListUserFromDtoToString(recruiterDtoModels);
            sandboxView.Interviewers = new UserMapper().MapListUserFromDtoToString(interwieverDtoModels);

            return sandboxView;
        }

        public MemoryStream MapListFromViewToExcel(IEnumerable<SandboxExcelViewModel> viewModels)
        {
            MemoryStream memoryStream = new MemoryStream();

            DataTable tableViewModels = (DataTable)JsonConvert.
                    DeserializeObject(JsonConvert.SerializeObject(viewModels), typeof(DataTable));

            using (var excelFile = new ExcelPackage(memoryStream))
            {
                var sheet = excelFile.Workbook.Worksheets.Add("Sandboxes");
                sheet.Cells.LoadFromDataTable(tableViewModels, true, OfficeOpenXml.Table.TableStyles.None);

                excelFile.Save();
            }

            memoryStream.Position = 0;

            return memoryStream;
        }
    }
}
