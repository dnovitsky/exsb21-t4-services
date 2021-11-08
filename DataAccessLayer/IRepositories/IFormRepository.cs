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
        void CreateAsync(FormEntityModel item);
        void Update(FormEntityModel item);
        void Delete(int id);
    }
}
