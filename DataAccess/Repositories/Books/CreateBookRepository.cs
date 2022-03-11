using Dapper.Transaction;
using DataAccess.Repositories.Books.Dtos;

namespace DataAccess.Repositories.Books
{
    public partial class BookRepository : Repository, IBookRepository
    {
        private const string insertBookSql =
@"INSERT INTO Book
(AuthorId, Name)
OUTPUT INSERTED.Id
VALUES
(@AuthorId, @Name);";

        public async Task<int> AddBook(CreateBookRequest book)
        {
            var t = await _connectionManager.GetOrCreateTransaction();
            var res = await t.ExecuteScalarAsync<int>(insertBookSql, book);
            return res;
        }
    }
}
