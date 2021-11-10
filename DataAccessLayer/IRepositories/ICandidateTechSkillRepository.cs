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
        Task<IEnumerable<CandidateTechSkillEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateTechSkillEntityModel>> FindByConditionAsync(Expression<Func<CandidateTechSkillEntityModel, bool>> expression);
        Task<CandidateTechSkillEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(CandidateTechSkillEntityModel item);
=======
        Task<CandidateTechSkillEntityModel> CreateAsync(CandidateTechSkillEntityModel item);
>>>>>>> dev
        void Update(CandidateTechSkillEntityModel item);
        void Delete(Guid id);
    }
}
