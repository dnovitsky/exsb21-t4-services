using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Service;

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

        public async Task<PagedList<T>> GetPageAsync(int pagesize, int pagenumber)
        {
            IEnumerable<T> list = await set.ToListAsync();
            int pages = (int)Math.Ceiling((double)list.Count()/(double)pagesize);
            IEnumerable<T> PageList = await set.Skip((pagenumber-1)*pagesize).Take(pagesize).ToListAsync();
            PagedList<T> pagedList = new PagedList<T>
            {
                PageList = PageList,
                CurrentPage = pagenumber,
                TotalPages = pages
            };
            return pagedList;
        }

        public virtual async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = set.Where(expression);
            return await query.ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(Guid id)
        {
            return await set.FindAsync(id);
        }

        public virtual async Task<T> CreateAsync(T item)
        {
            var entityEntry = await set.AddAsync(item);
            return entityEntry.Entity;
        }

        public virtual void Update(T item)
        {
            context.Update(item);
        }

        public virtual void Delete(Guid id)
        {
            T del_item = set.Find(id);
            if (del_item != null)
            {
                set.Remove(del_item);
            }
        }
    }
}
