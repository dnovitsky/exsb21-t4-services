using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFormRepository
    {
        Task<IEnumerable<FormEntityModel>> GetAllAsync();
        Task<IEnumerable<FormEntityModel>> FindByConditionAsync(Expression<Func<FormEntityModel, bool>> expression);
        Task<FormEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(FormEntityModel item);
=======
        Task<FormEntityModel> CreateAsync(FormEntityModel item);
>>>>>>> dev
        void Update(FormEntityModel item);
        void Delete(Guid id);
    }
}
