using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateRepository
    {
        IEnumerable<CandidateEntityModel> GetAll();
        IEnumerable<CandidateEntityModel> FindByCondition(Expression<Func<CandidateEntityModel, bool>> expression);
        void Create(CandidateEntityModel item);
        void Update(CandidateEntityModel item);
        void Delete(int id);
    }
}
