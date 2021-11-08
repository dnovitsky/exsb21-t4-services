using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserTeamRepository
    {
        Task<IEnumerable<UserTeamEntityModel>> GetAllAsync();
        Task<IEnumerable<UserTeamEntityModel>> FindByConditionAsync(Expression<Func<UserTeamEntityModel, bool>> expression);
        Task<UserTeamEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(UserTeamEntityModel item);
        void Update(UserTeamEntityModel item);
        void Delete(int id);
    }
}
