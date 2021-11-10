using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccessEntityModel> Accesses { get; set; }

        public DbSet<AccessFormEntityModel> AccessForms { get; set;}

        public DbSet<AvailabilityTypeEntityModel> AvailabilityTypes { get; set; }        

        public DbSet<CandidateEntityModel> Candidates { get; set; }
        public DbSet<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        public DbSet<CandidateProccesEntityModel> CandidatesProcceses { get; set; }
        public DbSet<CandidateProjectRoleEntityModel> CandidateProjectRoles { get; set; }
        public DbSet<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
        public DbSet<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }

        public DbSet<FeedbackEntityModel> Feedbacks { get; set; }
        public DbSet<FormEntityModel> Forms { get; set; }
        public DbSet<FunctionalRoleEntityModel> FunctionalRoles { get; set; }
        public DbSet<LanguageEntityModel> Languages { get; set; }
        public DbSet<LanguageLevelEntityModel> LanguageLevels { get; set; }
        public DbSet<RatingEntityModel> Ratings { get; set; }


        public DbSet<SandboxEntityModel> Sandboxes { get; set; }
        public DbSet<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }
        public DbSet<SkillEntityModel> Skills { get; set; }

        public DbSet<StackTechnologyEntityModel> StackTechnologies { get; set; }
        public DbSet<StatusEntityModel> Statuses { get; set; }
        public DbSet<TeamEntityModel> Teams { get; set; }

        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<UserFunctionalRoleEntityModel> UserFunctionalRoles { get; set; }
        public DbSet<UserLanguageEntityModel> UserLanguages { get; set; }
        public DbSet<UserRefreshTokenEntityModel> UserRefreshTokens { get; set; }
        public DbSet<UserSandBoxEntityModel> UserSandBoxes { get; set; }
        public DbSet<UserStackTechnologyEntityModel> UserStackTechnologies { get; set; }
        public DbSet<UserTeamEntityModel> UserTeams { get; set; }
        public DbSet<UserTechSkillEntityModel> UserTechSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CandidateSandboxConfiguration.OnModelCreating(modelBuilder);
            UserTeamConfiguration.OnModelCreating(modelBuilder);
        }

    }


}
