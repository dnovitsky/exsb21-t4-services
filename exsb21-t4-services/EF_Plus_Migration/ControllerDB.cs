using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EF_Plus_Migration
{
    class ControllerDB
    {
        private ApplicationDBContext db;

        public ControllerDB(string appsetting_json = "appsettings.json")
        {
            this.db = new ApplicationDBContext(this.generateOptionForDB(appsetting_json));
        }

        public void setUserToDB(User user)
        {
            Console.WriteLine("Start saving the User to the DB");
            this.db.Users.Add(user);
            this.db.SaveChanges();
            Console.WriteLine("User added successfully");
        }

        public void showAllUsersFromDB()
        {
            var users = this.db.Users.ToList();
            Console.WriteLine("Users List:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname} - {u.PrimarySkill} - {u.Location} - {u.CourseName}");
            }
            Console.Read();
        }

        private DbContextOptions<ApplicationDBContext> generateOptionForDB(string appsetting_json)
        {
            var builder = new ConfigurationBuilder();
            // set path to current directory
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // get config file from appsettings.json
            builder.AddJsonFile(appsetting_json);
            // create configuration
            var config = builder.Build();
            // get connection string
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            return optionsBuilder.UseSqlServer(connectionString).Options;
        }
    }
}
