using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateLanguage> CandidateLanguages { get; set; }
        public DbSet<CandidateSandbox> CandidateSandboxes { get; set; }
        public DbSet<CandidatesProcces> CandidatesProcceses { get; set; }
        public DbSet<CandidateTechSkill> CandidateTechSkills { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FunctionalRole> FunctionalRoles { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Sandbox> Sandboxes { get; set; }
        public DbSet<SandBoxTechSkill> SandBoxTechSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserSandBox> UserSandBoxes { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<UserTechSkill> UserTechSkill { get; set; }
    }
}
