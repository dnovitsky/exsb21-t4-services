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
        Task<IEnumerable<CandidateProccesEntityModel>> GetAllAsync(Func<IQueryable<CandidateProccesEntityModel>, IQueryable<CandidateProccesEntityModel>> include = null);
        Task<IEnumerable<CandidateProccesEntityModel>> FindByConditionAsync(Expression<Func<CandidateProccesEntityModel, bool>> expression);
        Task<CandidateProccesEntityModel> FindByIdAsync(int id);
        void CreateAsync(CandidateProccesEntityModel item);
        void UpdateAsync(CandidateProccesEntityModel item);
        void DeleteAsync(int id);
    }
}
