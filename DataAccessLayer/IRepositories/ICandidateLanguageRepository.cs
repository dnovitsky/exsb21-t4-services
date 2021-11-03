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
        Task<CandidateLanguageEntityModel> FindByIdAsync(int id);
        void CreateAsync(CandidateLanguageEntityModel item);
        void Update(CandidateLanguageEntityModel item);
        void Delete(int id);
    }
}
