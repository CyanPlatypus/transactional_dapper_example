using System.Data.Common;

namespace DataAccess.ConnectionFabrics
{
    public interface IDbConnectionFabric
    {
        public DbConnection CreateConnection();
    }
}