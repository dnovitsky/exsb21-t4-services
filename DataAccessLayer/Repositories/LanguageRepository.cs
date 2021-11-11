using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class LanguageRepository : Repository<LanguageEntityModel>, ILanguageRepository
    {
        public AppDbContext db;
        public LanguageRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task<LanguageEntityModel> FindByIdAsync(Guid id)
        {
            return await db.Languages.FindAsync(id);
        }
        public async Task<IEnumerable<LanguageEntityModel>> GetBySandboxId(Guid id)
        {
            //SandboxEntityModel Sandbox = await db.Sandboxes.FindAsync(id);
            //IEnumerable<SandboxLanguageEntityModel> SandboxLanguages = Sandbox.SandboxLanguages;
            //IEnumerable<LanguageEntityModel> result = db.Languages.Join(SandboxLanguages,
            //                                                            l => l.I
            // List  sandbox languages(id, id)
            // IEnumerable < LanguageEntityModel > result = db.Languages.Join(x => x.Id == Collection_ids.) // how to go throw array here

            //SandboxEntityModel Sandbox = await db.Sandboxes.FindAsync(id);
            //IEnumerable<SandboxLanguageEntityModel> SandboxLanguages = Sandbox.SandboxLanguages;

            IEnumerable<SandboxLanguageEntityModel> SandboxLanguage = db.SandboxLanguages.Where(s => s.SandboxId == id);
            IList<LanguageEntityModel> Language = new List<LanguageEntityModel> { };

            foreach (var a in SandboxLanguage)
            {
                Language.Add(db.Languages.Find(a.LanguageId));
            }
            return Language;
        }
        public async Task<IEnumerable<LanguageEntityModel>> GetAllAsync()
        {
            return await Task.Run(() => db.Languages.AsEnumerable());
        }
        public async Task CreateAsync(LanguageEntityModel item)
        {
            await db.Languages.AddAsync(item);
        }

        public void Update(LanguageEntityModel item)
        {
            db.Languages.Update(item);
            // db.SaveChanges();
        }
        public void Delete(Guid id)
        {

        }
    }
}
