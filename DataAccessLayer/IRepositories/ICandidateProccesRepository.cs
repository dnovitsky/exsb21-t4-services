using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProccesRepository
    {
        Task<IEnumerable<CandidateProccesEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateProccesEntityModel>> FindByConditionAsync(Expression<Func<CandidateProccesEntityModel, bool>> expression);
        Task<CandidateProccesEntityModel> FindByIdAsync(Guid id);
        Task<CandidateProccesEntityModel> CreateAsync(CandidateProccesEntityModel item);
        void Update(CandidateProccesEntityModel item);
        void Delete(Guid id);
    }
}
