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
        Task<IEnumerable<LanguageEntityModel>> GetAllAsync(Func<IQueryable<LanguageEntityModel>, IQueryable<LanguageEntityModel>> include = null);
        Task<IEnumerable<LanguageEntityModel>> FindByConditionAsync(Expression<Func<LanguageEntityModel, bool>> expression);
        Task<LanguageEntityModel> FindByIdAsync(int id);
        void CreateAsync(LanguageEntityModel item);
        void UpdateAsync(LanguageEntityModel item);
        void DeleteAsync(int id);
    }
}
