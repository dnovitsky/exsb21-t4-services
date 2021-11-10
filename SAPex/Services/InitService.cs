using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace SAPex.Services
{
    public class InitService
    {
        public static void Initial(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AppDbContext db = new AppDbContext(options))
            {
                if (!db.Sandboxes.Any())
                {
                    Guid id1 = new Guid("653fa839-37e8-41df-9fba-440a51466788");
                    Guid id2 = new Guid("653fa839-37e8-41df-9fba-440a51466789");
                    Guid id3 = new Guid("653fa839-37e8-41df-9fba-440a51466790");
                    Guid id4 = new Guid("653fa839-37e8-41df-9fba-440a51466791");
                    Guid id5 = new Guid("653fa839-37e8-41df-9fba-440a51466792");
                    Guid id6 = new Guid("653fa839-37e8-41df-9fba-440a51466793");
                    Guid id7 = new Guid("653fa839-37e8-41df-9fba-440a51466794");
                    Guid id8 = new Guid("653fa839-37e8-41df-9fba-440a51466795");

                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = id1,
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
                        Id = id2,
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
                        Id = id3,
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
                        Id = id4,
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
                        Id = id5,
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
                        Id = id6,
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
                        Id = id7,
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
                        Id = id8,
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

                // var test = db.Sandboxes.Find(id0);
                // Console.WriteLine(test.Name);
                // Console.WriteLine(test);
                // db.Sandboxes.Update(new SandboxEntityModel { Id = id1, Name = "UPD .Net & JS", MaxCandidates = 30, Description = "UPDdescription1" });

                // UnitOfWork initUnit = new UnitOfWork(db);
                // SandboxRepository rep = new SandboxRepository(db);
                // SandboxService service = new SandboxService(initUnit);
                // SandboxController controller1 = new SandboxController(service);

                db.SaveChanges();
            }
        }
    }
}
