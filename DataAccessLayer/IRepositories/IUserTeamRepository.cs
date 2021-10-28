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
        void Create(UserTeamEntityModel item);
        void Update(UserTeamEntityModel item);
        void Delete(int id);
    }
}
