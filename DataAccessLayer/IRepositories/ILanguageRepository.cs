using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<LanguageEntityModel>> GetAllAsync();
        Task<IEnumerable<LanguageEntityModel>> FindByConditionAsync(Expression<Func<LanguageEntityModel, bool>> expression);
        Task<LanguageEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(LanguageEntityModel item);
        void Update(LanguageEntityModel item);
        void Delete(Guid id);
    }
}
