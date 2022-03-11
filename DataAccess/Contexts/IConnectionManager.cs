using System.Data.Common;

namespace DataAccess.Contexts
{
    public interface IConnectionManager
    {
        public Task<DbTransaction> GetOrCreateTransaction();
        //public Task<DbConnection> GetConnection();
    }
}