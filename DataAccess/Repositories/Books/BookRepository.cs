using Dapper;
using Dapper.Transaction;
using DataAccess.Contexts;
using DataAccess.Repositories.Books.Dtos;

namespace DataAccess.Repositories.Books
{
    public partial class BookRepository : Repository, IBookRepository
    {
        public BookRepository(IConnectionManager transactionManager) : base(transactionManager) { }

    }
}