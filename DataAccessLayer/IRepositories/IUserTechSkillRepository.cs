using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserTechSkillRepository
    {
        Task<IEnumerable<UserTechSkillEntityModel>> GetAllAsync(Func<IQueryable<UserTechSkillEntityModel>, IQueryable<UserTechSkillEntityModel>> include = null);
        Task<IEnumerable<UserTechSkillEntityModel>> FindByConditionAsync(Expression<Func<UserTechSkillEntityModel, bool>> expression);
        Task<UserTechSkillEntityModel> FindByIdAsync(int id);
        void CreateAsync(UserTechSkillEntityModel item);
        void UpdateAsync(UserTechSkillEntityModel item);
        void DeleteAsync(int id);
    }
}
