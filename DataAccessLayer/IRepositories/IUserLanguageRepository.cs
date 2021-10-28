using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserLanguageRepository
    {
        IEnumerable<UserLanguageEntityModel> GetAll();
        IEnumerable<UserLanguageEntityModel> FindByCondition(Expression<Func<UserLanguageEntityModel, bool>> expression);
        void Create(UserLanguageEntityModel item);
        void Update(UserLanguageEntityModel item);
        void Delete(int id);
    }
}
