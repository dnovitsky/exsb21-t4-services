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
        void Create(LanguageEntityModel item);
        void Update(LanguageEntityModel item);
        void Delete(int id);
    }
}
