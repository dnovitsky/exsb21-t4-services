using System;
using Microsoft.EntityFrameworkCore;

namespace exsb21_t4_services.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<Country> migrationCountries { get; set; }
        public DbSet<Region> migrationRegions { get; set; }
    }
}
