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
        Task<IEnumerable<UserStackTechnologyEntityModel>> GetAllAsync(Func<IQueryable<UserStackTechnologyEntityModel>, IQueryable<UserStackTechnologyEntityModel>> include = null);
        Task<IEnumerable<UserStackTechnologyEntityModel>> FindByConditionAsync(Expression<Func<UserStackTechnologyEntityModel, bool>> expression);
        Task<UserStackTechnologyEntityModel> FindByIdAsync(int id);
        void CreateAsync(UserStackTechnologyEntityModel item);
        void UpdateAsync(UserStackTechnologyEntityModel item);
        void DeleteAsync(int id);
    }
}
