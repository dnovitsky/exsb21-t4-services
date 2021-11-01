using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProjectRoleRepository
    {
        Task<IEnumerable<CandidateProjectRoleEntityModel>> GetAllAsync(Func<IQueryable<CandidateProjectRoleEntityModel>, IQueryable<CandidateProjectRoleEntityModel>> include = null);
        Task<IEnumerable<CandidateProjectRoleEntityModel>> FindByConditionAsync(Expression<Func<CandidateProjectRoleEntityModel, bool>> expression);
        Task<CandidateProjectRoleEntityModel> FindByIdAsync(int id);
        void CreateAsync(CandidateProjectRoleEntityModel item);
        void UpdateAsync(CandidateProjectRoleEntityModel item);
        void DeleteAsync(int id);
    }
}
