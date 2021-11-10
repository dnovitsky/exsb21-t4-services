using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Service;

namespace DataAccessLayer.IRepositories
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<PagedList<T>> GetPageAsync(int pagesize, int pagenumber);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T,bool>> expression);
        Task<T> FindByIdAsync(Guid id);
        Task<T> CreateAsync(T item);
        void Update(T item);
        void Delete(Guid id);//SoftDelete??
    }
}
