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
        Task<IEnumerable<CandidateEntityModel>> GetAllAsync(Func<IQueryable<CandidateEntityModel>, IQueryable<CandidateEntityModel>> include = null);
        Task<IEnumerable<CandidateEntityModel>> FindByConditionAsync(Expression<Func<CandidateEntityModel, bool>> expression);
        Task<CandidateEntityModel> FindByIdAsync(int id);
        void CreateAsync(CandidateEntityModel item);
        void UpdateAsync(CandidateEntityModel item);
        void DeleteAsync(int id);
    }
}
