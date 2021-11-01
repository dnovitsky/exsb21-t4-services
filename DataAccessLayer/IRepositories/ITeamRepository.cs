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
        Task<IEnumerable<TeamEntityModel>> GetAllAsync(Func<IQueryable<TeamEntityModel>, IQueryable<TeamEntityModel>> include = null);
        Task<IEnumerable<TeamEntityModel>> FindByConditionAsync(Expression<Func<TeamEntityModel, bool>> expression);
        Task<TeamEntityModel> FindByIdAsync(int id);
        void CreateAsync(TeamEntityModel item);
        void UpdateAsync(TeamEntityModel item);
        void DeleteAsync(int id);
    }
}
