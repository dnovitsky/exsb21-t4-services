using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxLanguageRepository
    {
        Task<IEnumerable<SandboxLanguageEntityModel>> GetAllAsync();
        Task<IEnumerable<SandboxLanguageEntityModel>> FindByConditionAsync(Expression<Func<SandboxLanguageEntityModel, bool>> expression);
        Task<SandboxLanguageEntityModel> FindByIdAsync(Guid id);
        Task<SandboxLanguageEntityModel> CreateAsync(SandboxLanguageEntityModel item);
        Task UpdateBySandboxId(IEnumerable<SandboxLanguageEntityModel> sandboxLanguages);
        void Update(SandboxLanguageEntityModel item);
        void Delete(Guid id);
    }
}
