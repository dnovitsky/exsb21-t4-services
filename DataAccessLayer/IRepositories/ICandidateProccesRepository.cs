using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProccesRepository
    {
        IEnumerable<CandidateProccesEntityModel> GetAll();
        IEnumerable<CandidateProccesEntityModel> FindByCondition(Expression<Func<CandidateProccesEntityModel, bool>> expression);
        void Create(CandidateProccesEntityModel item);
        void Update(CandidateProccesEntityModel item);
        void Delete(int id);
    }
}
