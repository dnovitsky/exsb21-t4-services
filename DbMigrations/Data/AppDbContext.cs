using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CandidateEntityModel> Candidates { get; set; }
        public DbSet<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        public DbSet<CandidateProccesEntityModel> CandidatesProcceses { get; set; }
        public DbSet<CandidateProjectRoleEntityModel> CandidateProjectRoles { get; set; }
        public DbSet<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
        public DbSet<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }

        public DbSet<FeedbackEntityModel> Feedbacks { get; set; }
        public DbSet<FunctionalRoleEntityModel> FunctionalRoles { get; set; }
        public DbSet<LanguageEntityModel> Languages { get; set; }
        public DbSet<LanguageLevelEntityModel> LanguageLevels { get; set; }
        public DbSet<RatingEntityModel> Ratings { get; set; }
        public DbSet<SandboxEntityModel> Sandboxes { get; set; }
        public DbSet<SandBoxTechSkillEntityModel> SandBoxTechSkills { get; set; }
        public DbSet<SkillEntityModel> Skills { get; set; }
        public DbSet<StatusEntityModel> Statuses { get; set; }
        public DbSet<TeamEntityModel> Teams { get; set; }

        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<UserLanguageEntityModel> UserLanguages { get; set; }
        public DbSet<UserRoleEntityModel> UserRoles { get; set; }
        public DbSet<UserSandBoxEntityModel> UserSandBoxes { get; set; }
        public DbSet<UserTeamEntityModel> UserTeams { get; set; }
        public DbSet<UserTechSkillEntityModel> UserTechSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CandidateSandboxConfiguration.OnModelCreating(modelBuilder);
            UserSandboxConfiguration.OnModelCreating(modelBuilder);
            UserTeamConfiguration.OnModelCreating(modelBuilder);
        }

    }


}
