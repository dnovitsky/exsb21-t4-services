using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateTechSkillRepository
    {
        IEnumerable<CandidateTechSkillEntityModel> GetAll();
        IEnumerable<CandidateTechSkillEntityModel> FindByCondition(Expression<Func<CandidateTechSkillEntityModel, bool>> expression);
        void CreateAsync(CandidateTechSkillEntityModel item);
        void UpdateAsync(CandidateTechSkillEntityModel item);
        void DeleteAsync(int id);
    }
}
