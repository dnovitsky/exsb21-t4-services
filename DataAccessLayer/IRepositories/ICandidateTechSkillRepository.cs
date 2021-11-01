using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateTechSkillRepository
    {
        Task<IEnumerable<CandidateTechSkillEntityModel>> GetAllAsync(Func<IQueryable<CandidateTechSkillEntityModel>, IQueryable<CandidateTechSkillEntityModel>> include = null);
        Task<IEnumerable<CandidateTechSkillEntityModel>> FindByConditionAsync(Expression<Func<CandidateTechSkillEntityModel, bool>> expression);
        Task<CandidateTechSkillEntityModel> FindByIdAsync(int id);
        void CreateAsync(CandidateTechSkillEntityModel item);
        void UpdateAsync(CandidateTechSkillEntityModel item);
        void DeleteAsync(int id);
    }
}
