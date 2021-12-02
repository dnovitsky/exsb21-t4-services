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
<<<<<<< HEAD
        public AppDbContext(IConfiguration configuration) => db = new SqlConnection(Environment.GetEnvironmentVariable("MSSQL_CONNECTION_STRING"));
=======
        public AppDbContext(IConfiguration configuration) => db = new SqlConnection(configuration.GetConnectionString("SAPExDbConnection"));
>>>>>>> dev
        public IDbConnection Db { get { return db; } }
    }
}
