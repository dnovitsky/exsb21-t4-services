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
        Task<IEnumerable<FormEntityModel>> GetAllAsync(Func<IQueryable<FormEntityModel>, IQueryable<FormEntityModel>> include = null);
        Task<IEnumerable<FormEntityModel>> FindByConditionAsync(Expression<Func<FormEntityModel, bool>> expression);
        Task<FormEntityModel> FindByIdAsync(int id);
        void CreateAsync(FormEntityModel item);
        void UpdateAsync(FormEntityModel item);
        void DeleteAsync(int id);
    }
}
