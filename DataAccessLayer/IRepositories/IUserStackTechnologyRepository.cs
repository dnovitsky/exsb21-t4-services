using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserStackTechnologyRepository
    {
        IEnumerable<UserStackTechnologyEntityModel> GetAll();
        IEnumerable<UserStackTechnologyEntityModel> FindByCondition(Expression<Func<UserStackTechnologyEntityModel, bool>> expression);
        void CreateAsync(UserStackTechnologyEntityModel item);
        void UpdateAsync(UserStackTechnologyEntityModel item);
        void DeleteAsync(int id);
    }
}
