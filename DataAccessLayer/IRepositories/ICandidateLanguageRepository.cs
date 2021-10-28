using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateLanguageRepository
    {
        IEnumerable<CandidateLanguageEntityModel> GetAll();
        IEnumerable<CandidateLanguageEntityModel> FindByCondition(Expression<Func<CandidateLanguageEntityModel, bool>> expression);
        void Create(CandidateLanguageEntityModel item);
        void Update(CandidateLanguageEntityModel item);
        void Delete(int id);
    }
}
