using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamEntityModel>> GetAllAsync();
        Task<IEnumerable<TeamEntityModel>> FindByConditionAsync(Expression<Func<TeamEntityModel, bool>> expression);
        Task<TeamEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(TeamEntityModel item);
=======
        Task<TeamEntityModel> CreateAsync(TeamEntityModel item);
>>>>>>> dev
        void Update(TeamEntityModel item);
        void Delete(Guid id);
    }
}
