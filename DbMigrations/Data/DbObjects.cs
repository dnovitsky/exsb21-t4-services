using DbMigrations.EntityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DbMigrations.Data
{
    public class DbObjects
    {
        public static void Initial(string connectionString)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //var options = optionsBuilder.UseSqlServer(connectionString).Options;

            //using (AppDbContext db = new AppDbContext(options))
            //{
            //    db.TestTable.Add(new TestModel { Name = " third " });
            //    db.SaveChanges();
            //}

        }
    }
}
