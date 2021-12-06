using DbMigrations.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class CleanHelper
    {
        public static void CleanTablesData(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AppDbContext db = new AppDbContext(options))
            {
                // db.RemoveRange(db);
                db.Events.RemoveRange(db.Events);
                db.Locations.RemoveRange(db.Locations);
                db.Sandboxes.RemoveRange(db.Sandboxes);
                db.AvailabilityTypes.RemoveRange(db.AvailabilityTypes);
                db.LanguageLevels.RemoveRange(db.LanguageLevels);
                db.Languages.RemoveRange(db.Languages);
                db.StackTechnologies.RemoveRange(db.StackTechnologies);
                db.Users.RemoveRange(db.Users);

                db.SandboxStackTechnologies.RemoveRange(db.SandboxStackTechnologies);
                db.SandboxLanguages.RemoveRange(db.SandboxLanguages);
                db.UserSandBoxes.RemoveRange(db.UserSandBoxes);
                db.UserFunctionalRoles.RemoveRange(db.UserFunctionalRoles);

                db.Statuses.RemoveRange(db.Statuses);
                db.Skills.RemoveRange(db.Skills);

                db.Candidates.RemoveRange(db.Candidates);
                db.CandidateLanguages.RemoveRange(db.CandidateLanguages);
                db.CandidateTechSkills.RemoveRange(db.CandidateTechSkills);
                db.CandidateProjectRoles.RemoveRange(db.CandidateProjectRoles);
                db.CandidateSandboxes.RemoveRange(db.CandidateSandboxes);
                db.CandidatesProcceses.RemoveRange(db.CandidatesProcceses);

                db.Feedbacks.RemoveRange(db.Feedbacks);
                db.UserCandidateSandboxes.RemoveRange(db.UserCandidateSandboxes);
                // db.AppSettings.RemoveRange(db.AppSettings);

                db.SaveChanges();
            }
        }
    }
}
