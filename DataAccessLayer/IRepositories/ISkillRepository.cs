using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillEntityModel>> GetAllAsync(Func<IQueryable<SkillEntityModel>, IQueryable<SkillEntityModel>> include = null);
        Task<IEnumerable<SkillEntityModel>> FindByConditionAsync(Expression<Func<SkillEntityModel, bool>> expression);
        Task<SkillEntityModel> FindByIdAsync(int id);
        void CreateAsync(SkillEntityModel item);
        void UpdateAsync(SkillEntityModel item);
        void DeleteAsync(int id);
    }
}
