using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IAccessFormRepository AccessForms { get; }
        IAccessRepository Accesses { get; }
        ICandidateLanguageRepository CandidateLanguages { get; }
        ICandidateProccesRepository CandidateProcceses { get; }
        ICandidateProjectRoleRepository CandidateProjectRoles { get; }
        ICandidateRepository Candidates { get; }
        ICandidateSandboxRepository CandidateSandboxes { get; }
        ICandidateTechSkillRepository CandidateTechSkills { get; }
        IFeedbackRepository Feedbacks { get; }
        IFormRepository Forms { get; }
        IFunctionalRoleRepository FunctionalRoles { get; }
        ILanguageLevelRepository LanguageLevels { get; }
        ILanguageRepository Languages { get; }
        IRatingRepository Ratings { get; }
        ISandboxRepository Sandboxes { get; }
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
        Task SaveAsync();

        void Save();
    }
}
