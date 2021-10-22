using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<TestModel> TestTable { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateLanguage> CandidateLanguages { get; set; }
        public DbSet<CandidateSandbox> CandidateSandboxes { get; set; }
        public DbSet<CandidatesProcces> CandidatesProcceses { get; set; }
        public DbSet<CandidateTechSkill> CandidateTechSkills { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MentorRole> MentorRoles { get; set; }
        public DbSet<MentorSandBox> MentorSandBoxes { get; set; }
        public DbSet<MentorTeam> MentorTeam { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Sandbox> Sandboxes { get; set; }
        public DbSet<SandBoxTechSkill> SandBoxTechSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLanguage> UserLanguage { get; set; }
        public DbSet<UserTechSkill> UserTechSkill { get; set; }
    }
}
