using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFMig1.Models
{
    public class AppContextDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public AppContextDb()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4AVOV83\\SQLEXPRESS;Database=TestEFMig1;Trusted_Connection=True;");
        }
    }
}
