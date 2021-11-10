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
        Task<IEnumerable<UserTechSkillEntityModel>> GetAllAsync();
        Task<IEnumerable<UserTechSkillEntityModel>> FindByConditionAsync(Expression<Func<UserTechSkillEntityModel, bool>> expression);
        Task<UserTechSkillEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(UserTechSkillEntityModel item);
        void Update(UserTechSkillEntityModel item);
        void Delete(Guid id);
    }
}
