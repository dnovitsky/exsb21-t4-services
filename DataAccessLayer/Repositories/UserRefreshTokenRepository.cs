using System;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class UserRefreshTokenRepository : Repository<UserRefreshTokenEntityModel>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(AppDbContext context)
            : base(context)
        { }
    }
}
