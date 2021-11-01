using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProjectRoleRepository
    {
        IEnumerable<CandidateProjectRoleEntityModel> GetAll();
        IEnumerable<CandidateProjectRoleEntityModel> FindByCondition(Expression<Func<CandidateProjectRoleEntityModel, bool>> expression);
        void CreateAsync(CandidateProjectRoleEntityModel item);
        void UpdateAsync(CandidateProjectRoleEntityModel item);
        void DeleteAsync(int id);
    }
}
