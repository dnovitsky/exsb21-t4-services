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

        private IAccessFormRepository accessForms;
        private IAccessRepository accesses;
        private IAvailabilityTypeRepository availabilityTypes;
        private ICandidateLanguageRepository candidateLanguages;
        private ICandidateProccesRepository candidateProcceses;
        private ICandidateProjectRoleRepository candidateProjectRoles;
        private ICandidateRepository candidates;
        private ICandidateSandboxRepository candidateSandboxes;
        private ICandidateTechSkillRepository candidateTechSkills;
        private IFeedbackRepository feedbacks;
        private IFileRepository files;
        private IFormRepository forms;
        private IFunctionalRoleRepository functionalRoles;
        private ILanguageLevelRepository languageLevels;
        private ILanguageRepository languages;
        private ILocationRepository locations;
        private IRatingRepository ratings;
        private ISandboxLanguageRepository sandboxLanguages;
        private ISandboxRepository sandboxes;
        private ISandboxStackTechnologyRepository sandboxStackTechnologies;
        private ISkillRepository skills;
        private IStackTechnologyRepository stackTechnologies;
        private IStatusRepository statuses;
        private ITeamRepository teams;
        private IUserFunctionalRoleRepository userFunctionalRoles;
        private IUserLanguageRepository userLanguages;
        private IUserRepository users;
        private IUserStackTechnologyRepository userStackTechnologies;
        private IUserSandBoxRepository userSandBoxes;
        private IUserTeamRepository userTeams;
        private IUserTechSkillRepository userTechSkills;
        private IUserRefreshTokenRepository userRefreshTokens;
        private ICalendarEventRepository calendarEvents;
        private IInterviewEventRepository interviewEvents;
        private IGoogleAccessTokenRepository googleAccessTokens;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IAccessFormRepository AccessForms
        {
            get
            {
                if (accessForms == null)
                {
                    accessForms = new AccessFormRepository(context);
                }
                return accessForms;
            }
        }

        public IAccessRepository Accesses
        {
            get
            {
                if (accesses == null)
                {
                    accesses = new AccessRepository(context);
                }
                return accesses;
            }
        }

        public IAvailabilityTypeRepository AvailabilityTypes
        {
            get
            {
                if (availabilityTypes == null)
                {
                    availabilityTypes = new AvailabilityTypeRepository(context);
                }
                return availabilityTypes;
            }
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
        public IFileRepository Files
        {
            get
            {
                if (files == null)
                {
                    files = new FileRepository(context);
                }
                return files;
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

        public ILocationRepository Locations
        {
            get
            {
                if (locations == null)
                {
                    locations = new LocationRepository(context);
                }
                return locations;
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

        public ISandboxLanguageRepository SandboxLanguages
        {
            get
            {
                if (sandboxLanguages == null)
                {
                    sandboxLanguages = new SandboxLanguageRepository(context);
                }
                return sandboxLanguages;
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

        public ISandboxStackTechnologyRepository SandboxTechSkill
        {
            get
            {
                if (sandboxStackTechnologies == null)
                {
                    sandboxStackTechnologies = new SandboxStackTechnologyRepository(context);
                }
                return sandboxStackTechnologies;
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

        public IUserStackTechnologyRepository UserRoles
        {
            get
            {
                if (userStackTechnologies == null)
                {
                    userStackTechnologies = new UserStackTechnologyRepository(context);
                }
                return userStackTechnologies;
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

        public IFormRepository Forms
        {
            get
            {
                if (forms == null)
                {
                    forms = new FormRepository(context);
                }
                return forms;
            }
        }

        public ISandboxStackTechnologyRepository SandboxStackTechnologies
        {
            get
            {
                if (sandboxStackTechnologies == null)
                {
                    sandboxStackTechnologies = new SandboxStackTechnologyRepository(context);
                }
                return sandboxStackTechnologies;
            }
        }

        public IStackTechnologyRepository StackTechnologies
        {
            get
            {
                if (stackTechnologies == null)
                {
                    stackTechnologies = new StackTechnologyRepository(context);
                }
                return stackTechnologies;
            }
        }

        public IUserFunctionalRoleRepository UserFunctionalRoles
        {
            get
            {
                if (userFunctionalRoles == null)
                {
                    userFunctionalRoles = new UserFunctionalRoleRepository(context);
                }
                return userFunctionalRoles;
            }
        }

        public IUserStackTechnologyRepository UserStackTechnologies
        {
            get
            {
                if (userStackTechnologies == null)
                {
                    userStackTechnologies = new UserStackTechnologyRepository(context);
                }
                return userStackTechnologies;
            }
        }


        public IUserRefreshTokenRepository UserRefreshTokens
        {
            get
            {
                if (userRefreshTokens == null)
                {
                    userRefreshTokens = new UserRefreshTokenRepository(context);
                }
                return userRefreshTokens;
            }
        }

        public ICalendarEventRepository CalendarEvents
        {
            get
            {
                if (calendarEvents == null)
                {
                    calendarEvents = new CalendarEventRepository(context);
                }
                return calendarEvents;
            }
        }
        public IInterviewEventRepository InterviewEvents
        {
            get
            {
                if (interviewEvents == null)
                {
                    interviewEvents = new InterviewEventRepository(context);
                }
                return interviewEvents;
            }
        }

        public IGoogleAccessTokenRepository GoogleAccessTokens
        {
            get
            {
                if (googleAccessTokens == null)
                {
                    googleAccessTokens = new GoogleAccessTokenRepository(context);
                }
                return googleAccessTokens;
            }
        }

        public async Task SaveAsync()
        {
             await context.SaveChangesAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.DisposeAsync();
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
