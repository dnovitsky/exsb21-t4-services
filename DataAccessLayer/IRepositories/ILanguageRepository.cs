using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ILanguageRepository
    {
        IEnumerable<LanguageEntityModel> GetAll();
        IEnumerable<LanguageEntityModel> FindByCondition(Expression<Func<LanguageEntityModel, bool>> expression);
        void CreateAsync(LanguageEntityModel item);
        void UpdateAsync(LanguageEntityModel item);
        void DeleteAsync(int id);
    }
}
