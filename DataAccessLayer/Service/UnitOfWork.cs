using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.Data;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Service
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext context;

        private ICandidateLanguageRepository candidateLanguages;
        private ICandidateProccesRepository candidateProcceses;
        private ICandidateProjectRoleRepository candidateProjectRoles;
        private ICandidateRepository candidates;
        private ICandidateSandboxRepository candidateSandboxes;
        private ICandidateTechSkillRepository candidateTechSkills;
        private IFeedbackRepository feedbacks;
        private IFunctionalRoleRepository functionalRoles;
        private ILanguageLevelRepository languageLevels;
        private ILanguageRepository languages;
        private IRatingRepository ratings;
        private ISandboxRepository sandboxes;
        private ISandboxTechSkillRepository sandboxTechSkill;
        private ISkillRepository skills;
        private IStatusRepository statuses;
        private ITeamRepository teams;
        private IUserLanguageRepository userLanguages;
        private IUserRepository users;
        private IUserRoleRepository userRoles;
        private IUserSandBoxRepository userSandBoxes;
        private IUserTeamRepository userTeams;
        private IUserTechSkillRepository userTechSkills;

        public UnitOfWork(AppDbContext context)
        {
            this.context= context;
        }
        public ICandidateLanguageRepository CandidateLanguages
        {
            get
            {
                if (candidateLanguages == null)
                {
                    candidateLanguages= new CandidateLanguageRepository(context);
                }
                return candidateLanguages;
            }
        }

        public ICandidateProccesRepository CandidateProcceses
        {
            get
            {
                if (candidateProcceses == null)
                {
                    candidateProcceses = new CandidateProccesRepository(context);
                }
                return candidateProcceses;
            }
        }

        public ICandidateProjectRoleRepository CandidateProjectRoles
        {
            get
            {
                if (candidateProjectRoles == null)
                {
                    candidateProjectRoles = new CandidateProjectRoleRepository(context);
                }
                return candidateProjectRoles;
            }
        }

        public ICandidateRepository Candidates
        {
            get
            {
                if (candidates == null)
                {
                    candidates = new CandidateRepository(context);
                }
                return candidates;
            }
        }

        public ICandidateSandboxRepository CandidateSandboxes
        {
            get
            {
                if (candidateSandboxes == null)
                {
                    candidateSandboxes = new CandidateSandboxRepository(context);
                }
                return candidateSandboxes;
            }
        }

        public ICandidateTechSkillRepository CandidateTechSkills
        {
            get
            {
                if (candidateTechSkills == null)
                {
                    candidateTechSkills = new CandidateTechSkillRepository(context);
                }
                return candidateTechSkills;
            }
        }

        public IFeedbackRepository Feedbacks
        {
            get
            {
                if (feedbacks == null)
                {
                    feedbacks = new FeedbackRepository(context);
                }
                return feedbacks;
            }
        }

        public IFunctionalRoleRepository FunctionalRoles
        {
            get
            {
                if (functionalRoles == null)
                {
                    functionalRoles = new FunctionalRoleRepository(context);
                }
                return functionalRoles;
            }
        }

        public ILanguageLevelRepository LanguageLevels
        {
            get
            {
                if (languageLevels == null)
                {
                    languageLevels = new LanguageLevelRepository(context);
                }
                return languageLevels;
            }
        }

        public ILanguageRepository Languages
        {
            get
            {
                if (languages == null)
                {
                    languages = new LanguageRepository(context);
                }
                return languages;
            }
        }

        public IRatingRepository Ratings
        {
            get
            {
                if (ratings == null)
                {
                    ratings = new RatingRepository(context);
                }
                return ratings;
            }
        }

        public ISandboxRepository Sandboxes
        {
            get
            {
                if (sandboxes == null)
                {
                    sandboxes = new SandboxRepository(context);
                }
                return sandboxes;
            }
        }

        public ISandboxTechSkillRepository SandboxTechSkill
        {
            get
            {
                if (sandboxTechSkill == null)
                {
                    sandboxTechSkill = new SandboxTechSkillRepository(context);
                }
                return sandboxTechSkill;
            }
        }

        public ISkillRepository Skills
        {
            get
            {
                if (skills == null)
                {
                    skills = new SkillRepository(context);
                }
                return skills;
            }
        }

        public IStatusRepository Statuses
        {
            get
            {
                if (statuses == null)
                {
                    statuses = new StatusRepository(context);
                }
                return statuses;
            }
        }

        public ITeamRepository Teams
        {
            get
            {
                if (teams == null)
                {
                    teams = new TeamRepository(context);
                }
                return teams;
            }
        }

        public IUserLanguageRepository UserLanguages
        {
            get
            {
                if (userLanguages == null)
                {
                    userLanguages = new UserLanguageRepository(context);
                }
                return userLanguages;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (users == null)
                {
                    users = new UserRepository(context);
                }
                return users;
            }
        }

        public IUserRoleRepository UserRoles
        {
            get
            {
                if (userRoles == null)
                {
                    userRoles = new UserRoleRepository(context);
                }
                return userRoles;
            }
        }

        public IUserSandBoxRepository UserSandBoxes
        {
            get
            {
                if (userSandBoxes == null)
                {
                    userSandBoxes = new UserSandBoxRepository(context);
                }
                return userSandBoxes;
            }
        }

        public IUserTeamRepository UserTeams
        {
            get
            {
                if (userTeams == null)
                {
                    userTeams = new UserTeamRepository(context);
                }
                return userTeams;
            }
        }

        public IUserTechSkillRepository UserTechSkills
        {
            get
            {
                if (userTechSkills == null)
                {
                    userTechSkills = new UserTechSkillRepository(context);
                }
                return userTechSkills;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
