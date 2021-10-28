using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxRepository
    {
        IEnumerable<SandboxEntityModel> GetAll();
        IEnumerable<SandboxEntityModel> FindByCondition(Expression<Func<SandboxEntityModel, bool>> expression);
        void Create(SandboxEntityModel item);
        void Update(SandboxEntityModel item);
        void Delete(int id);
    }
}
