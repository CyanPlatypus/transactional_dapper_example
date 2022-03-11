using DataAccess.Config;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess.ConnectionFabrics
{
    public class SqlConnectionFabric : IDbConnectionFabric
    {
        private readonly DbConfiguration _configuration;

        public SqlConnectionFabric(DbConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.ConnectionString);
        }
    }
}