using DbMigrations.Data;
using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    internal class TestDataHelper
    {
        public static void InitTestData(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AppDbContext db = new AppDbContext(options))
            {

                Guid idSb1 = Guid.NewGuid();
                Guid idSb2 = Guid.NewGuid();
                Guid idSb3 = Guid.NewGuid();
                Guid idSb4 = Guid.NewGuid();
                Guid idSb5 = Guid.NewGuid();
                Guid idSb6 = Guid.NewGuid();
                Guid idSb7 = Guid.NewGuid();
                Guid idSb8 = Guid.NewGuid();

                Guid idLg1 = Guid.NewGuid();
                Guid idLg2 = Guid.NewGuid();
                Guid idLg3 = Guid.NewGuid();
                Guid idLg4 = Guid.NewGuid();
                Guid idLg5 = Guid.NewGuid();

                Guid idSt1 = Guid.NewGuid();
                Guid idSt2 = Guid.NewGuid();
                Guid idSt3 = Guid.NewGuid();
                Guid idSt4 = Guid.NewGuid();
                Guid idSt5 = Guid.NewGuid();

                if (!db.Sandboxes.Any())
                {
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb1,
                        Name = ".Net & JS",
                        MaxCandidates = 10,
                        Description = "description .Net & JS",
                        CreateDate = new DateTime(2021, 1, 1),
                        StartDate = new DateTime(2021, 1, 2),
                        EndDate = new DateTime(2021, 1, 3),
                        StartRegistration = new DateTime(2021, 1, 4),
                        EndRegistration = new DateTime(2021, 1, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb2,
                        Name = "Python",
                        MaxCandidates = 22,
                        Description = "description Python",
                        CreateDate = new DateTime(2021, 2, 1),
                        StartDate = new DateTime(2021, 2, 2),
                        EndDate = new DateTime(2021, 2, 3),
                        StartRegistration = new DateTime(2021, 2, 4),
                        EndRegistration = new DateTime(2021, 2, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb3,
                        Name = "PHP",
                        MaxCandidates = 33,
                        Description = "description PHP",
                        CreateDate = new DateTime(2021, 3, 1),
                        StartDate = new DateTime(2021, 3, 2),
                        EndDate = new DateTime(2021, 3, 3),
                        StartRegistration = new DateTime(2021, 3, 4),
                        EndRegistration = new DateTime(2021, 3, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb4,
                        Name = "C++",
                        MaxCandidates = 45,
                        Description = "description C++",
                        CreateDate = new DateTime(2021, 4, 1),
                        StartDate = new DateTime(2021, 4, 2),
                        EndDate = new DateTime(2021, 4, 3),
                        StartRegistration = new DateTime(2021, 4, 4),
                        EndRegistration = new DateTime(2021, 4, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb5,
                        Name = "QA",
                        MaxCandidates = 56,
                        Description = "description QA",
                        CreateDate = new DateTime(2021, 5, 1),
                        StartDate = new DateTime(2021, 5, 2),
                        EndDate = new DateTime(2021, 5, 3),
                        StartRegistration = new DateTime(2021, 5, 4),
                        EndRegistration = new DateTime(2021, 5, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb6,
                        Name = "BA",
                        MaxCandidates = 62,
                        Description = "description BA",
                        CreateDate = new DateTime(2021, 6, 1),
                        StartDate = new DateTime(2021, 6, 2),
                        EndDate = new DateTime(2021, 6, 3),
                        StartRegistration = new DateTime(2021, 6, 4),
                        EndRegistration = new DateTime(2021, 6, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb7,
                        Name = "Manager",
                        MaxCandidates = 77,
                        Description = "description Manager",
                        CreateDate = new DateTime(2021, 7, 1),
                        StartDate = new DateTime(2021, 7, 2),
                        EndDate = new DateTime(2021, 7, 3),
                        StartRegistration = new DateTime(2021, 7, 4),
                        EndRegistration = new DateTime(2021, 7, 5),
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb8,
                        Name = "Devops",
                        MaxCandidates = 81,
                        Description = "description Devops",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                    });
                }
                db.SaveChanges();

                if (!db.AvailabilityTypes.Any())
                {
                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Less than 4 hours",
                        OrderLevel = 0,
                    });

                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "4-6 hours",
                        OrderLevel = 1,
                    });

                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "6-infinity hours",
                        OrderLevel = 2,
                    });
                }
                db.SaveChanges();

                if (!db.LanguageLevels.Any())
                {
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Beginner (A1)",
                        OrderLevel = 0,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Elementary (A2)",
                        OrderLevel = 1,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Intermediate (B1)",
                        OrderLevel = 2,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Upper-Intermediate (B2)",
                        OrderLevel = 3,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Advanced (C1)",
                        OrderLevel = 4,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Proficient (C2)",
                        OrderLevel = 5,
                    });

                }
                db.SaveChanges();

                if (!db.Languages.Any())
                {
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg1,
                        Name = "English"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg2,
                        Name = "Russian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg3,
                        Name = "Georgian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg4,
                        Name = "Latvian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg5,
                        Name = "Polish"
                    });
                }
                db.SaveChanges();

                if (!db.StackTechnologies.Any())
                {
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = ".Net"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "JS"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Java"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Devops"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Python"
                    });
                }
                db.SaveChanges();

                //if (!db.SandboxStackTechnologies.Any())
                //{
                //    db.Add(new SandboxStackTechnologyEntityModel
                //    {
                //        Id = Guid.NewGuid(),
                //        SandboxId = idSb1,
                //        StackTechnologyId = idSt1
                //    });

                //    db.Add(new SandboxStackTechnologyEntityModel
                //    {
                //        Id = Guid.NewGuid(),
                //        SandboxId = idSb1,
                //        StackTechnologyId = idSt2
                //    });

                //    db.Add(new SandboxStackTechnologyEntityModel
                //    {
                //        Id = Guid.NewGuid(),
                //        SandboxId = idSb2,
                //        StackTechnologyId = idSt2
                //    });

                //    db.Add(new SandboxStackTechnologyEntityModel
                //    {
                //        Id = Guid.NewGuid(),
                //        SandboxId = idSb2,
                //        StackTechnologyId = idSt3
                //    });

                //    db.Add(new SandboxStackTechnologyEntityModel
                //    {
                //        Id = Guid.NewGuid(),
                //        SandboxId = idSb3,
                //        StackTechnologyId = idSt4
                //    });

                //}
                //db.SaveChanges();

                db.SaveChanges();
            }
        }
    }
}
