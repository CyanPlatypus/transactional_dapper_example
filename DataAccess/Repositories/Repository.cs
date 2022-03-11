using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class Repository
    {
        protected readonly IConnectionManager _connectionManager;

        public Repository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
    }
}