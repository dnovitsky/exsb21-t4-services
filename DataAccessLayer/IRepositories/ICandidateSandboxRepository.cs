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
        void Create(CandidateSandboxEntityModel item);
        void Update(CandidateSandboxEntityModel item);
        void Delete(int id);
    }
}
