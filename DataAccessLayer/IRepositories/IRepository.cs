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
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T,bool>> expression);
        Task<T> FindByIdAsync(Guid id);
        Task CreateAsync(T item);
        void Update(T item);
        void Delete(Guid id);//SoftDelete??
    }
}
