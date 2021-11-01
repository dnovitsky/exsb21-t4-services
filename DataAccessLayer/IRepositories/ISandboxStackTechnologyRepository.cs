using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxStackTechnologyRepository
    {
        IEnumerable<SandboxStackTechnologyEntityModel> GetAll();
        IEnumerable<SandboxStackTechnologyEntityModel> FindByCondition(Expression<Func<SandboxStackTechnologyEntityModel, bool>> expression);
        void CreateAsync(SandboxStackTechnologyEntityModel item);
        void UpdateAsync(SandboxStackTechnologyEntityModel item);
        void DeleteAsync(int id);
    }
}
