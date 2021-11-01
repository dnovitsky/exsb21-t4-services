using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ITeamRepository
    {
        IEnumerable<TeamEntityModel> GetAll();
        IEnumerable<TeamEntityModel> FindByCondition(Expression<Func<TeamEntityModel, bool>> expression);
        void CreateAsync(TeamEntityModel item);
        void UpdateAsync(TeamEntityModel item);
        void DeleteAsync(int id);
    }
}
