using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxTechSkillRepository
    {
        IEnumerable<SandBoxTechSkillEntityModel> GetAll();
        IEnumerable<SandBoxTechSkillEntityModel> FindByCondition(Expression<Func<SandBoxTechSkillEntityModel, bool>> expression);
        void Create(SandBoxTechSkillEntityModel item);
        void Update(SandBoxTechSkillEntityModel item);
        void Delete(int id);
    }
}
