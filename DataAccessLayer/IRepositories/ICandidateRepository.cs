using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateEntityModel>> FindByConditionAsync(Expression<Func<CandidateEntityModel, bool>> expression);
        Task<CandidateEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(CandidateEntityModel item);
=======
        Task<CandidateEntityModel> CreateAsync(CandidateEntityModel item);
>>>>>>> dev
        void Update(CandidateEntityModel item);
        void Delete(Guid id);
    }
}
