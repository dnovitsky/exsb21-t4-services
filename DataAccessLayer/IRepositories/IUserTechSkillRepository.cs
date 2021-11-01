using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserTechSkillRepository
    {
        IEnumerable<UserTechSkillEntityModel> GetAll();
        IEnumerable<UserTechSkillEntityModel> FindByCondition(Expression<Func<UserTechSkillEntityModel, bool>> expression);
        void CreateAsync(UserTechSkillEntityModel item);
        void UpdateAsync(UserTechSkillEntityModel item);
        void DeleteAsync(int id);
    }
}
