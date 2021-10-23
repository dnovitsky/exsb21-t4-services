using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SAPex.Data
{
    public class DapperDbContext
    {
        private IDbConnection db;
        public DapperDbContext(IConfiguration configuration) => db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        public IDbConnection Db { get { return db; } }
    }
}