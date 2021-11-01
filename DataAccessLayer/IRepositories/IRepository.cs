using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByCondition(Expression<Func<T,bool>> expression);
        void CreateAsync(T item);
        void UpdateAsync(T item);
        void DeleteAsync(int id);//SoftDelete??
    }
}
