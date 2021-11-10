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
        Task<IEnumerable<SkillEntityModel>> GetAllAsync();
        Task<IEnumerable<SkillEntityModel>> FindByConditionAsync(Expression<Func<SkillEntityModel, bool>> expression);
        Task<SkillEntityModel> FindByIdAsync(Guid id);
        Task<SkillEntityModel> CreateAsync(SkillEntityModel item);
        void Update(SkillEntityModel item);
        void Delete(Guid id);
    }
}
