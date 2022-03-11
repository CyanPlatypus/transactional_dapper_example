using Dapper;
using Dapper.Transaction;
using DataAccess.Repositories.Authors.Dtos;

namespace DataAccess.Repositories.Authors
{
    public partial class AuthorRepository : Repository, IAuthorRepository
    {
        private const string getAuthorByIdSql =
@"SELECT a.Id, a.FullName
FROM Author a
WHERE a.Id = @Id;";

        public async Task<GetAuthorResponse> GetAuthor(int id)
        {
            var t = await _connectionManager.GetOrCreateTransaction();
            var entity = await t.QueryFirstOrDefaultAsync<GetAuthorResponse>(getAuthorByIdSql, new { Id = id });
            return entity;
        }
    }
}
