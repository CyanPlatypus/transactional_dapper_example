using DataAccess.ConnectionFabrics;
using System.Data;
using System.Data.Common;

namespace DataAccess.Contexts
{
    public class DataAccessContext : IDataAccessContext, IConnectionManager, IDisposable
    {
        //internal DbConnection Connection => _connection;
        private DbConnection _connection;
        private DbTransaction? _transaction;
        //private UnitOfWork? _unitOfWork;

        //internal IDbTransaction Transaction => _transaction ?? 
        //internal IDbTransaction _transaction;

        private bool _isDisposed;

        public DataAccessContext(IDbConnectionFabric dbConnectionFabric)
        {
            _connection = dbConnectionFabric.CreateConnection();
        }

        public async Task<DbTransaction> GetOrCreateTransaction()
        {
            await OpenConnectionIfClosed();
            _transaction = _transaction ?? await _connection.BeginTransactionAsync();
            return _transaction;
        }

        public async Task Commit()
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync();
                _transaction.Dispose();
                _transaction = null;

                await _connection.CloseAsync(); //shoul we close a connection here aswell?
            }
        }

        //public async Task<DbConnection> GetConnection()
        //{
        //    await OpenConnectionIfClosed();
        //    return _connection;
        //}

        private async Task OpenConnectionIfClosed()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                await _connection.OpenAsync();
            }
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _transaction?.Dispose();

            _connection?.Dispose();

            _isDisposed = true;
        }

    }

    //internal class UnitOfWork : IDisposable
    //{
    //    public IDbTransaction Transaction => _transaction;
    //    private IDbTransaction _transaction;

    //    private bool _isDisposed;

    //    public UnitOfWork(IDbConnection dbConnection)
    //    {
    //        _transaction = dbConnection.BeginTransaction();
    //    }

    //    public void Commit()
    //    {
    //        _transaction.Commit();
    //    }

    //    public void Rollback()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        if (_isDisposed)
    //        {
    //            return;
    //        }

    //        _transaction?.Dispose();
    //    }
    //}
}