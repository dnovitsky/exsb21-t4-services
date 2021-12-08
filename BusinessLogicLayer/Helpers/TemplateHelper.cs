using DbMigrations.EntityModels;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class TemplateHelper
    {
        public async static Task<string> GenerateFullName(CandidateEntityModel candidate)
        {
            return await Task.Run(() => candidate.Name + " " + candidate.Surname);
        }
    }
}
