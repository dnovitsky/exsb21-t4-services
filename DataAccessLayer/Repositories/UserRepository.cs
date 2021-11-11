using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : Repository<UserEntityModel>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        { }

        //public override async Task<IEnumerable<UserEntityModel>>  FindByConditionAsync(Expression<Func<UserEntityModel, bool>> expression)
        //{
        //    IQueryable<UserEntityModel> query = set.Where(expression).Include(x => x.UserRoles);
        //    return await query.ToListAsync();
        //}

    }
}
