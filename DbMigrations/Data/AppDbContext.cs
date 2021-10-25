using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TestModel> TestTable { get; set; }
    }
}
