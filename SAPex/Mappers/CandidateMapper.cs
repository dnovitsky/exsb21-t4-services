using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers.Mapping
{
    public class CandidateMapper : Profile
    {
        private SandboxMapper _sandboxMapper;
        private LocationMapper _locationMapper;
        private LanguageMapper _languageMapper;
        private LanguageLevelMapper _languageLevelMapper;
        private SkillMapper _skillMapper;
        private FeedbackMapper _feedbackMapper;
        private StatusMapper _statusMapper;

        public CandidateMapper()
        {
            _sandboxMapper = new SandboxMapper();
            _locationMapper = new LocationMapper();
            _languageMapper = new LanguageMapper();
            _languageLevelMapper = new LanguageLevelMapper();
            _skillMapper = new SkillMapper();
            _feedbackMapper = new FeedbackMapper();
            _statusMapper = new StatusMapper();
        }

        public CreateCandidateDtoModel MapNewCandidateToDto(CreateCandidateViewModel candidateVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCandidateViewModel, CreateCandidateDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => x.Location))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.PhoneNumber, y => y.MapFrom(x => x.PhoneNumber))
                    .ForMember(x => x.Motivation, y => y.MapFrom(x => x.Motivation))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.AvailabillityTypeId, y => y.MapFrom(x => x.AvailabillityTypeId))
                    .ForMember(x => x.TimeContact, y => y.MapFrom(x => x.TimeContact))
                    .ForMember(x => x.IsJoinToExadel, y => y.MapFrom(x => x.IsJoinToExadel))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.IsAgreement, y => y.MapFrom(x => x.IsAgreement))
                    .ForMember(x => x.EnglishLevelId, y => y.MapFrom(x => x.EnglishLevelId))
                    .ForMember(x => x.SandboxPreferredLanguageId, y => y.MapFrom(x => x.SandboxPreferredLanguageId))
                    .ForMember(x => x.PrimaryTechnologyId, y => y.MapFrom(x => x.PrimaryTechnologyId))
                    .ForMember(x => x.SandboxId, y => y.MapFrom(x => x.SandboxId)));
            var mapper = new Mapper(config);

            CreateCandidateDtoModel candidateDto = mapper.Map<CreateCandidateViewModel, CreateCandidateDtoModel>(candidateVM);
            return candidateDto;
        }

        public CandidateViewModel MapCandidateDtoToVM(CandidateDtoModel candidateVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => _locationMapper.MapLocationFromDtoToView(x.Location)))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => MapCandidateLanguagesDtoToVM(x.CandidateLanguages)))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => MapCandidateTechSkillsDtoToVM(x.CandidateTechSkills)))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => MapCandidateSandboxesDtoToVM(x.CandidateSandboxes))));

            var mapper = new Mapper(config);

            CandidateViewModel candidateDto = mapper.Map<CandidateDtoModel, CandidateViewModel>(candidateVM);
            return candidateDto;
        }

        public IEnumerable<CandidateViewModel> MapCandidateDtoToVM(IEnumerable<CandidateDtoModel> candidateDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateDtoModel, CandidateViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                    .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname))
                    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
                    .ForMember(x => x.Location, y => y.MapFrom(x => _locationMapper.MapLocationFromDtoToView(x.Location)))
                    .ForMember(x => x.Skype, y => y.MapFrom(x => x.Skype))
                    .ForMember(x => x.Phone, y => y.MapFrom(x => x.Phone))
                    .ForMember(x => x.ProfessionaCertificates, y => y.MapFrom(x => x.ProfessionaCertificates))
                    .ForMember(x => x.AdditionalSkills, y => y.MapFrom(x => x.AdditionalSkills))
                    .ForMember(x => x.CandidateLanguages, y => y.MapFrom(x => MapCandidateLanguagesDtoToVM(x.CandidateLanguages)))
                    .ForMember(x => x.CandidateTechSkills, y => y.MapFrom(x => MapCandidateTechSkillsDtoToVM(x.CandidateTechSkills)))
                    .ForMember(x => x.CandidateSandboxes, y => y.MapFrom(x => MapCandidateSandboxesDtoToVM(x.CandidateSandboxes))));

            var mapper = new Mapper(config);

            IList<CandidateViewModel> candidateVMList = new List<CandidateViewModel>() { };

            if (candidateDM != null)
            {
                foreach (var candidate in candidateDM)
                {
                    CandidateViewModel candidateVM = mapper.Map<CandidateDtoModel, CandidateViewModel>(candidate);
                    candidateVMList.Add(candidateVM);
                }
            }

            return candidateVMList;
        }

        private IEnumerable<CandidateLanguagesViewModel> MapCandidateLanguagesDtoToVM(IEnumerable<CandidateLanguageDtoModel> candidateSandboxesDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateLanguageDtoModel, CandidateLanguagesViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Language, y => y.MapFrom(x => _languageMapper.MapLanguageFromDtoToView(x.Language)))
                    .ForMember(x => x.LanguageLevel, y => y.MapFrom(x => _languageLevelMapper.MapToVM(x.LanguageLevel))));

            var mapper = new Mapper(config);

            IList<CandidateLanguagesViewModel> candidateDtoList = new List<CandidateLanguagesViewModel>() { };

            foreach (var candidateSandboxes in candidateSandboxesDM)
            {
                CandidateLanguagesViewModel candidateSandboxesVM = mapper.Map<CandidateLanguageDtoModel, CandidateLanguagesViewModel>(candidateSandboxes);
                candidateDtoList.Add(candidateSandboxesVM);
            }

            return candidateDtoList;
        }

        private IEnumerable<CandidateTechSkillsViewModel> MapCandidateTechSkillsDtoToVM(IEnumerable<CandidateTechSkillDtoModel> candidateTechSkills)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateTechSkillDtoModel, CandidateTechSkillsViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Skill, y => y.MapFrom(x => _skillMapper.MapSkillFromDtoToView(x.Skill))));

            var mapper = new Mapper(config);

            IList<CandidateTechSkillsViewModel> candidateTechSkillsVM = new List<CandidateTechSkillsViewModel>() { };

            foreach (var candidateTechSkill in candidateTechSkills)
            {
                CandidateTechSkillsViewModel candidateTechSkillVM = mapper.Map<CandidateTechSkillDtoModel, CandidateTechSkillsViewModel>(candidateTechSkill);
                candidateTechSkillsVM.Add(candidateTechSkillVM);
            }

            return candidateTechSkillsVM;
        }

        private IEnumerable<CandidateSandboxeViewModel> MapCandidateSandboxesDtoToVM(IEnumerable<CandidateSandboxDtoModel> candidateSandboxesDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateSandboxDtoModel, CandidateSandboxeViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Sandbox, y => y.MapFrom(x => _sandboxMapper.MapSbFromDtoToView(x.Sandbox)))
                    .ForMember(x => x.CurrentJob, y => y.MapFrom(x => x.CurrentJob))
                    .ForMember(x => x.CandidateProjectRole, y => y.MapFrom(x => MapCandidateProjectRoleDtoToVM(x.CandidateProjectRole)))
                    .ForMember(x => x.CandidateProcesses, y => y.MapFrom(x => MapCandidateProcessesDtoToVM(x.CandidateProcesses))));

            var mapper = new Mapper(config);

            IList<CandidateSandboxeViewModel> candidateDtoList = new List<CandidateSandboxeViewModel>() { };

            foreach (var candidateSandboxes in candidateSandboxesDM)
            {
                CandidateSandboxeViewModel candidateSandboxesVM = mapper.Map<CandidateSandboxDtoModel, CandidateSandboxeViewModel>(candidateSandboxes);
                candidateDtoList.Add(candidateSandboxesVM);
            }

            return candidateDtoList;
        }

        private IEnumerable<CandidateProcessViewModel> MapCandidateProcessesDtoToVM(IEnumerable<CandidateProcessDtoModel> candidateProcessesDtoModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcessDtoModel, CandidateProcessViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Status, y => y.MapFrom(x => _statusMapper.MapDtoToView(x.Status)))
                    .ForMember(x => x.TestResult, y => y.MapFrom(x => x.TestResult))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Feedbacks, y => y.MapFrom(x => _feedbackMapper.MapListToView(x.Feedbacks)))
                    .ForMember(x => x.СandidateProccessTestTasks, y => y.MapFrom(x => CandidateProccessTestTasksProfile(x.СandidateProccessTestTasks))));

            var mapper = new Mapper(config);

            IList<CandidateProcessViewModel> candidateProcessesVM = new List<CandidateProcessViewModel>() { };

            foreach (var candidateProcess in candidateProcessesDtoModel)
            {
                CandidateProcessViewModel candidateProcessVM = mapper.Map<CandidateProcessDtoModel, CandidateProcessViewModel>(candidateProcess);
                candidateProcessesVM.Add(candidateProcessVM);
            }

            return candidateProcessesVM;
        }

        public CandidateProjectRoleViewModel MapCandidateProjectRoleDtoToVM(CandidateProjectRoleDtoModel candidateProjectRoleDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProjectRoleDtoModel, CandidateProjectRoleViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            CandidateProjectRoleViewModel candidateProjectRole = mapper.Map<CandidateProjectRoleDtoModel, CandidateProjectRoleViewModel>(candidateProjectRoleDM);
            return candidateProjectRole;
        }

        private IEnumerable<CandidateProcessTestTasksViewModel> CandidateProccessTestTasksProfile(IEnumerable<CandidateProcessTestTaskDtoModel> candidateProccessTestTasksDM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateProcessTestTaskDtoModel, CandidateProcessTestTasksViewModel>()
                    .ForMember(x => x.TestFileId, y => y.MapFrom(x => x.TestFileId)));

            var mapper = new Mapper(config);

            IList<CandidateProcessTestTasksViewModel> candidateProccessTestTasksVM = new List<CandidateProcessTestTasksViewModel>() { };

            foreach (var candidateProccessTestTask in candidateProccessTestTasksDM)
            {
                CandidateProcessTestTasksViewModel candidateProccessTestTaskVM = mapper.Map<CandidateProcessTestTaskDtoModel, CandidateProcessTestTasksViewModel>(candidateProccessTestTask);
                candidateProccessTestTasksVM.Add(candidateProccessTestTaskVM);
            }

            return candidateProccessTestTasksVM;
        }
    }
}
