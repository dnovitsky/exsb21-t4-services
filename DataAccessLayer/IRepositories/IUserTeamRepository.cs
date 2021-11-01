using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserTeamRepository
    {
        IEnumerable<UserTeamEntityModel> GetAll();
        IEnumerable<UserTeamEntityModel> FindByCondition(Expression<Func<UserTeamEntityModel, bool>> expression);
        void CreateAsync(UserTeamEntityModel item);
        void UpdateAsync(UserTeamEntityModel item);
        void DeleteAsync(int id);
    }
}
