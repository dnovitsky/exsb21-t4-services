using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IStatusRepository
    {
        IEnumerable<StatusEntityModel> GetAll();
        IEnumerable<StatusEntityModel> FindByCondition(Expression<Func<StatusEntityModel, bool>> expression);
        void Create(StatusEntityModel item);
        void Update(StatusEntityModel item);
        void Delete(int id);
    }
}
