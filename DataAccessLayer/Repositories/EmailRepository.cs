using System;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class EmailRepository : Repository<EmailEntityModel>, IEmailRepository
    {
        public EmailRepository(AppDbContext context)
            : base(context)
        { }
    }
}
