using System;
using System.Threading.Tasks;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IAccessFormRepository AccessForms { get; }
        IAccessRepository Accesses { get; }
        IAvailabilityTypeRepository AvailabilityTypes { get; }
        ICandidateLanguageRepository CandidateLanguages { get; }
        ICandidateProccesRepository CandidateProcceses { get; }
        ICandidateProjectRoleRepository CandidateProjectRoles { get; }
        ICandidateRepository Candidates { get; }
        ICandidateSandboxRepository CandidateSandboxes { get; }
        ICandidateTechSkillRepository CandidateTechSkills { get; }
        IFeedbackRepository Feedbacks { get; }
        IFileRepository Files { get; }
        ICandidateProccessTestTaskRepository CandidateProccessTestTasks { get; }
        IFormRepository Forms { get; }
        IFunctionalRoleRepository FunctionalRoles { get; }
        ILanguageLevelRepository LanguageLevels { get; }
        ILanguageRepository Languages { get; }
        ILocationRepository Locations { get; }
        ISandboxRepository Sandboxes { get; }
        ISandboxLanguageRepository SandboxLanguages { get; }
        ISandboxStackTechnologyRepository SandboxStackTechnologies { get; }
        ISkillRepository Skills { get; }
        IStackTechnologyRepository StackTechnologies { get; }
        IStatusRepository Statuses { get; }
        ITeamRepository Teams { get; }
        IUserFunctionalRoleRepository UserFunctionalRoles { get; }
        IUserLanguageRepository UserLanguages { get; }
        IUserRepository Users { get; }
        IUserSandBoxRepository UserSandBoxes { get; }
        IUserStackTechnologyRepository UserStackTechnologies { get; }
        IUserTeamRepository UserTeams { get; }
        IUserTechSkillRepository UserTechSkills { get; }
        IUserRefreshTokenRepository UserRefreshTokens { get; }
        IEventRepository Events { get; }
        IGoogleAccessTokenRepository GoogleAccessTokens { get; }
        IEventMemberRepository EventMembers { get; }

        IUserCandidateSandboxRepository UserCandidateSandboxes { get; }
        Task SaveAsync();

        public void Save();
    }
}
