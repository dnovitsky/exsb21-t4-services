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
        void CreateAsync(SandboxEntityModel item);
        void UpdateAsync(SandboxEntityModel item);
        void DeleteAsync(int id);
    }
}
