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
        void Create(CandidateProjectRoleEntityModel item);
        void Update(CandidateProjectRoleEntityModel item);
        void Delete(int id);
    }
}
