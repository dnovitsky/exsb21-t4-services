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
        Task<IEnumerable<CandidateProjectRoleEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateProjectRoleEntityModel>> FindByConditionAsync(Expression<Func<CandidateProjectRoleEntityModel, bool>> expression);
        Task<CandidateProjectRoleEntityModel> FindByIdAsync(Guid id);

        Task<CandidateProjectRoleEntityModel> CreateAsync(CandidateProjectRoleEntityModel item);

        void Update(CandidateProjectRoleEntityModel item);
        void Delete(Guid id);
    }
}
