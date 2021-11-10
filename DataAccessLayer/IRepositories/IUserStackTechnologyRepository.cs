using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserStackTechnologyRepository
    {
        Task<IEnumerable<UserStackTechnologyEntityModel>> GetAllAsync();
        Task<IEnumerable<UserStackTechnologyEntityModel>> FindByConditionAsync(Expression<Func<UserStackTechnologyEntityModel, bool>> expression);
        Task<UserStackTechnologyEntityModel> FindByIdAsync(Guid id);
        Task<UserStackTechnologyEntityModel> CreateAsync(UserStackTechnologyEntityModel item);
        void Update(UserStackTechnologyEntityModel item);
        void Delete(Guid id);
    }
}
