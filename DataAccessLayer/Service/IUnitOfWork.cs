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
        ICandidateLanguageRepository CandidateLanguages { get; }
        ICandidateProccesRepository CandidateProcceses { get; }
        ICandidateProjectRoleRepository CandidateProjectRoles { get; }
        ICandidateRepository Candidates { get; }
        ICandidateSandboxRepository CandidateSandboxes { get; }
        ICandidateTechSkillRepository CandidateTechSkills { get; }
        IFeedbackRepository Feedbacks { get; }
        IFunctionalRoleRepository FunctionalRoles { get; }
        ILanguageLevelRepository LanguageLevels { get; }
        ILanguageRepository Languages { get; }
        IRatingRepository Ratings { get; }
        ISandboxRepository Sandboxes { get; }
        ISandboxTechSkillRepository SandboxTechSkill { get; }
        ISkillRepository Skills { get; }
        IStatusRepository Statuses { get; }
        ITeamRepository Teams { get; }
        IUserLanguageRepository UserLanguages { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IUserSandBoxRepository UserSandBoxes { get; }
        IUserTeamRepository UserTeams { get; }
        IUserTechSkillRepository UserTechSkills { get; }
        void Save();
    }
}
