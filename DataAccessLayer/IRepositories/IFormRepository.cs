using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFormRepository
    {
        IEnumerable<FormEntityModel> GetAll();
        IEnumerable<FormEntityModel> FindByCondition(Expression<Func<FormEntityModel, bool>> expression);
        void CreateAsync(FormEntityModel item);
        void UpdateAsync(FormEntityModel item);
        void DeleteAsync(int id);
    }
}
