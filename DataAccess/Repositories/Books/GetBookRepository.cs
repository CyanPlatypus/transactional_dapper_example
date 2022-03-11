using Dapper;
using Dapper.Transaction;
using DataAccess.Repositories.Books.Dtos;

namespace DataAccess.Repositories.Books
{
    public partial class BookRepository : Repository, IBookRepository
    {
        private const string getBookByIdSql =
@"SELECT b.Id, b.AuthorId, b.Name, b.AuthorId, a.Name as AuthorName
FROM Book b
LEFT JOIN Author a ON b.AuthorId = a.Id
WHERE b.Id = @Id;";

        public async Task<GetBookResponse> GetBook(int id)
        {
            var t = await _connectionManager.GetOrCreateTransaction();
            var book = await t.QueryFirstOrDefaultAsync<GetBookResponse>(getBookByIdSql, new { Id = id });
            return book;
        }
    }
}
