using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


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
                if (!db.AvailabilityTypes.Any())
                {
                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Less than 4 hours"
                    });

                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "4-6 hours"
                    });

                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "6-infinity hours"
                    });
                }

                if (!db.LanguageLevels.Any())
                {
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Beginner(A1)"
                    });
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Elementary(A2)"
                    });
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Intermediate(B1)"
                    });
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Upper-Intermediate(B2)"
                    });
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Advanced(C1)"
                    });
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Proficient(C2)"
                    });
                    
                }
                db.SaveChanges();
            }
        }
    }
}
