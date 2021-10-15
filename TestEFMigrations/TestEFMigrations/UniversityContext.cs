using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace TestEFMigrations
{
    class UniversityContext: DbContext 
    {
        //public UniversityContext(): base("UniversityContext") { }

        public DbSet<Student> StudentsSet { get; set; }

        public UniversityContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
        // DESKTOP-4AVOV83\SQLEXPRESS
    }
}
