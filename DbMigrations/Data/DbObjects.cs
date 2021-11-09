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
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AppDbContext db = new AppDbContext(options))
            {
                if (!db.Availabilities.Any())
                {
                    Guid id1 = new Guid("653fa839-37e8-41df-9fba-440a51466788");
                    Guid id2 = new Guid("653fa839-37e8-41df-9fba-440a51466789");
                    Guid id3 = new Guid("653fa839-37e8-41df-9fba-440a51466790");

                    db.Availabilities.Add(new AvailabilityEntityModel
                    {
                        Id = id1,
                        Name = "Less than 4 hours"
                    });
                    db.Availabilities.Add(new AvailabilityEntityModel
                    {
                        Id = id2,
                        Name = "4-6 hours"
                    });
                    db.Availabilities.Add(new AvailabilityEntityModel
                    {
                        Id = id3,
                        Name = "6-infinity hours"
                    });
                }

                db.SaveChanges();
            }
        }
    }
}
