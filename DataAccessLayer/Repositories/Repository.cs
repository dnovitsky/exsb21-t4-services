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
        protected readonly DbSet<T> set;

        protected Repository(AppDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>(); 
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = set.Where(expression);
            return await query.ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public virtual async void CreateAsync(T item)
        {
            await set.AddAsync(item);
        }

        public virtual void Update(T item)
        {
            context.Update(item);
        }

        public virtual void Delete(int id)
        {
            T del_item = set.Find(id);
            if (del_item != null)
            {
                set.Remove(del_item);
            }
        }
    }
}
