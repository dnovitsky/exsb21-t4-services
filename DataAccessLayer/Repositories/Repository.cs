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
        public AppDbContext context;
        public Repository(AppDbContext context)
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

        public virtual void Create(T item)
        {
            context.Set<T>().Add(item);
        }

        public virtual void Delete(int id)
        {
            T del_item = context.Set<T>().Find(id);
            if (del_item != null)
            {
                context.Set<T>().Remove(del_item);
            }
        }

        public virtual void Update(T item)
        {

            context.Entry(context.Set<T>()).State = EntityState.Modified;
        }
    }
}
