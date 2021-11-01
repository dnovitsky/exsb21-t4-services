using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateSandboxRepository
    {
        IEnumerable<CandidateSandboxEntityModel> GetAll();
        IEnumerable<CandidateSandboxEntityModel> FindByCondition(Expression<Func<CandidateSandboxEntityModel, bool>> expression);
        void CreateAsync(CandidateSandboxEntityModel item);
        void UpdateAsync(CandidateSandboxEntityModel item);
        void DeleteAsync(int id);
    }
}
