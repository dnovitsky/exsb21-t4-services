using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IStackTechnologyRepository
    {
        IEnumerable<StackTechnologyEntityModel> GetAll();
        IEnumerable<StackTechnologyEntityModel> FindByCondition(Expression<Func<StackTechnologyEntityModel, bool>> expression);
        void CreateAsync(StackTechnologyEntityModel item);
        void UpdateAsync(StackTechnologyEntityModel item);
        void DeleteAsync(int id);
    }
}
