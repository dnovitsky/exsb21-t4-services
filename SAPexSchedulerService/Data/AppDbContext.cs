using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SAPexSchedulerService.Data
{
    public class AppDbContext : DbContext
    {
        private IDbConnection db;
        public AppDbContext(IConfiguration configuration) => db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        public IDbConnection Db { get { return db; } }
    }
}
