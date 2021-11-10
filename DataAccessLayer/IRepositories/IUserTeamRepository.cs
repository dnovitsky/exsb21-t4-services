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
<<<<<<< HEAD
        void CreateAsync(UserTeamEntityModel item);
=======
        Task<UserTeamEntityModel> CreateAsync(UserTeamEntityModel item);
>>>>>>> dev
        void Update(UserTeamEntityModel item);
        void Delete(Guid id);
    }
}
