using System;
using Microsoft.EntityFrameworkCore;

namespace EF_Plus_Migration
{
    class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
