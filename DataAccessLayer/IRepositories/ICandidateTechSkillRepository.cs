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
        void Create(CandidateTechSkillEntityModel item);
        void Update(CandidateTechSkillEntityModel item);
        void Delete(int id);
    }
}
