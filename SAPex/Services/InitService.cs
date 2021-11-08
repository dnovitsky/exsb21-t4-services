using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbMigrations.Data;
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
                Guid id1 = new Guid("653fa839-37e8-41df-9fba-440a51466788");
                Guid id2 = new Guid("653fa839-37e8-41df-9fba-440a51466789");
                Guid id3 = new Guid("653fa839-37e8-41df-9fba-440a51466790");
                Guid id4 = new Guid("653fa839-37e8-41df-9fba-440a51466791");
                Guid id5 = new Guid("653fa839-37e8-41df-9fba-440a51466792");
                Guid id6 = new Guid("653fa839-37e8-41df-9fba-440a51466793");
                Guid id7 = new Guid("653fa839-37e8-41df-9fba-440a51466794");

                // db.Sandboxes.Add(new SandboxEntityModel { Id = id1, Name = ".Net & JS", MaxCandidates = 3, Description = "description1" });
                // db.Sandboxes.Add(new SandboxEntityModel { Id = id2, Name = "Python", MaxCandidates = 10, Description = "description2" });
                // db.Sandboxes.Add(new SandboxEntityModel { Id = id3, Name = "PHP", MaxCandidates = 34, Description = "description3" });
                // db.Sandboxes.Add(new SandboxEntityModel { Id = id4, Name = "C++", MaxCandidates = 38, Description = "description4" });
                // db.Sandboxes.Add(new SandboxEntityModel { Id = id5, Name = "BA ", MaxCandidates = 12, Description = "description5" });
                // db.Sandboxes.Add(new SandboxEntityModel { Id = id6, Name = "QA", MaxCandidates = 67, Description = "description6" });
                // db.Sandboxes.Add(new SandboxEntityModel { Id = id7, Name = "Devops", MaxCandidates = 11, Description = "description7" });

                // UnitOfWork initUnit = new UnitOfWork(db);
                // SandboxRepository rep = new SandboxRepository(db);
                // SandboxService service = new SandboxService(initUnit);
                // SandboxController controller1 = new SandboxController(service);

                // db.SaveChanges();
            }
        }
    }
}
