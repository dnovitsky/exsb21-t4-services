using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISkillRepository
    {
        IEnumerable<SkillEntityModel> GetAll();
        IEnumerable<SkillEntityModel> FindByCondition(Expression<Func<SkillEntityModel, bool>> expression);
        void Create(SkillEntityModel item);
        void Update(SkillEntityModel item);
        void Delete(int id);
    }
}
