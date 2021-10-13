using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace exsb21_t4_services.Data
{
    public class DapperDbContext
    {
        private IDbConnection db;
        public DapperDbContext(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public IDbConnection Db { get { return db; } }
    }
}
