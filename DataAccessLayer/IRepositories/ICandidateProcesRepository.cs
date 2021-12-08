using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProcesRepository
    {
        Task<IEnumerable<CandidateProcesEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateProcesEntityModel>> FindByConditionAsync(Expression<Func<CandidateProcesEntityModel, bool>> expression);
        Task<CandidateProcesEntityModel> FindByIdAsync(Guid id);

        Task<CandidateProcesEntityModel> CreateAsync(CandidateProcesEntityModel item);

        void Update(CandidateProcesEntityModel item);
        void Delete(Guid id);
    }
}
