using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateRepository
    {
        IEnumerable<CandidateEntityModel> GetAll();
        CandidateEntityModel Search(string search);
        void Create(CandidateEntityModel item);
        void Update(CandidateEntityModel item);
        void Delete(int id);
    }
}
