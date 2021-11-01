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

        public virtual async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            IQueryable<T> queryWithInclude = include?.Invoke(set) ?? set.AsQueryable();

            return await queryWithInclude.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = set.Where(expression);
            return await query.ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await Task.Run(() => set.Find(id));
        }

        public virtual async void CreateAsync(T item)
        {
            await set.AddAsync(item);
        }

        public async void UpdateAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item can not be null");

            await Task.Run(() => context.Update(item));
        }

        public virtual async void DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                T del_item = set.Find(id);
                if (del_item != null)
                {
                    set.Remove(del_item);
                }
            });            
        }
    }
}
