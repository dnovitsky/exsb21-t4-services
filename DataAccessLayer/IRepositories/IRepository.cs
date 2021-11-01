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
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include = null);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T,bool>> expression);
        Task<T> FindByIdAsync(int id);
        void CreateAsync(T item);
        void UpdateAsync(T item);
        void DeleteAsync(int id);//SoftDelete??
    }
}
