using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserLanguageRepository
    {
        Task<IEnumerable<UserLanguageEntityModel>> GetAllAsync();
        Task<IEnumerable<UserLanguageEntityModel>> FindByConditionAsync(Expression<Func<UserLanguageEntityModel, bool>> expression);
        Task<UserLanguageEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(UserLanguageEntityModel item);
=======
        Task<UserLanguageEntityModel> CreateAsync(UserLanguageEntityModel item);
>>>>>>> dev
        void Update(UserLanguageEntityModel item);
        void Delete(Guid id);
    }
}
