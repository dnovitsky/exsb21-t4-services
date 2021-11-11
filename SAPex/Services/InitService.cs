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
