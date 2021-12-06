using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<AccessEntityModel> Accesses { get; set; }

        public DbSet<AccessFormEntityModel> AccessForms { get; set;}


        public DbSet<AppSettingEntityModel> AppSettings { get; set; }

        public DbSet<AvailabilityTypeEntityModel> AvailabilityTypes { get; set; }        


        public DbSet<CandidateEntityModel> Candidates { get; set; }
        public DbSet<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        public DbSet<CandidateProcesEntityModel> CandidatesProcceses { get; set; }
        public DbSet<CandidateProjectRoleEntityModel> CandidateProjectRoles { get; set; }
        public DbSet<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
        public DbSet<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }

        public DbSet<FeedbackEntityModel> Feedbacks { get; set; }
        public DbSet<FileEntityModel> Files { get; set; }
        public DbSet<FormEntityModel> Forms { get; set; }
        public DbSet<FunctionalRoleEntityModel> FunctionalRoles { get; set; }
        public DbSet<LanguageEntityModel> Languages { get; set; }

        public DbSet<LocationEntityModel> Locations { get; set; }
        public DbSet<LanguageLevelEntityModel> LanguageLevels { get; set; }


        public DbSet<SandboxEntityModel> Sandboxes { get; set; }
        public DbSet<SandboxLanguageEntityModel> SandboxLanguages { get; set; }
        public DbSet<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }
        public DbSet<SkillEntityModel> Skills { get; set; }

        public DbSet<StackTechnologyEntityModel> StackTechnologies { get; set; }
        public DbSet<StatusEntityModel> Statuses { get; set; }
        public DbSet<TeamEntityModel> Teams { get; set; }

        public DbSet<UserCandidateSandboxEntityModel> UserCandidateSandboxes { get; set; }
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<UserFunctionalRoleEntityModel> UserFunctionalRoles { get; set; }
        public DbSet<UserLanguageEntityModel> UserLanguages { get; set; }
        public DbSet<UserRefreshTokenEntityModel> UserRefreshTokens { get; set; }
        public DbSet<UserSandBoxEntityModel> UserSandBoxes { get; set; }
        public DbSet<UserStackTechnologyEntityModel> UserStackTechnologies { get; set; }
        public DbSet<UserTeamEntityModel> UserTeams { get; set; }
        public DbSet<UserTechSkillEntityModel> UserTechSkills { get; set; }
        public DbSet<CalendarEventEntityModel> CalendarEvents { get; set; }
        public DbSet<InterviewEventEntityModel> InterviewEvents { get; set; }
        public DbSet<EventEntityModel> Events { get; set; }
        public DbSet<GoogleAccessTokenEntityModel> GoogleAccessTokens { get; set; }
        public DbSet<EventMemberEntityModel> EventMembers { get; set; }
        public DbSet<EmailEntityModel> Emails { get; set; }


        public DbSet<CandidateProcessTestTaskEntityModel> CandidateProccessTestTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CandidateSandboxConfiguration.OnModelCreating(modelBuilder);
            UserTeamConfiguration.OnModelCreating(modelBuilder);
            CandidateProcessTestTaskConfiguration.OnModelCreating(modelBuilder);
        }

    }


}
