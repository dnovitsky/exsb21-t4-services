using System;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class GoogleAccessTokenRepository : Repository<GoogleAccessTokenEntityModel>, IGoogleAccessTokenRepository
    {
        public GoogleAccessTokenRepository(AppDbContext context)
            : base(context)
        { }
    }
}
