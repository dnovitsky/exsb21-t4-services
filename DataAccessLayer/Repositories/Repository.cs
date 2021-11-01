using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly AppDbContext context;
        protected Repository(AppDbContext context)
        {
            this.context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public virtual async void CreateAsync(T item)
        {
            await Task.Run(() => context.Set<T>().Add(item));            
        }

        public virtual async void DeleteAsync(int id) //Удаление в отдельных репозиториях
        {
            await Task.Run(() =>
            {
                T del_item = context.Set<T>().Find(id);
                if (del_item != null)
                {
                    context.Set<T>().Remove(del_item);
                }
            });            
        }

        public virtual async void UpdateAsync(T item)
        {
            await Task.Run(() => context.Entry(context.Set<T>()).State = EntityState.Modified);
        }
    }
}
