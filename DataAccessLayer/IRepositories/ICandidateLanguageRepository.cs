using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateLanguageRepository
    {
        Task<IEnumerable<CandidateLanguageEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateLanguageEntityModel>> FindByConditionAsync(Expression<Func<CandidateLanguageEntityModel, bool>> expression);
        Task<CandidateLanguageEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(CandidateLanguageEntityModel item);
=======
        Task<CandidateLanguageEntityModel> CreateAsync(CandidateLanguageEntityModel item);
>>>>>>> dev
        void Update(CandidateLanguageEntityModel item);
        void Delete(Guid id);
    }
}
