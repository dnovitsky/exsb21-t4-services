using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ILanguageLevelRepository
    {
        IEnumerable<LanguageLevelEntityModel> GetAll();
        IEnumerable<LanguageLevelEntityModel> FindByCondition(Expression<Func<LanguageLevelEntityModel, bool>> expression);
        void CreateAsync(LanguageLevelEntityModel item);
        void UpdateAsync(LanguageLevelEntityModel item);
        void DeleteAsync(int id);
    }
}
