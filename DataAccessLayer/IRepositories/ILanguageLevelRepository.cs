using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ILanguageLevelRepository
    {
        Task<IEnumerable<LanguageLevelEntityModel>> GetAllAsync();
        Task<IEnumerable<LanguageLevelEntityModel>> FindByConditionAsync(Expression<Func<LanguageLevelEntityModel, bool>> expression);
        Task<LanguageLevelEntityModel> FindByIdAsync(Guid id);
        Task<LanguageLevelEntityModel> CreateAsync(LanguageLevelEntityModel item);
        void Update(LanguageLevelEntityModel item);
        void Delete(Guid id);
    }
}
