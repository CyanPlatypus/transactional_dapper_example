using Dapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Authors.Dtos;

namespace DataAccess.Repositories.Authors
{
    public partial class AuthorRepository : Repository, IAuthorRepository
    {
        public AuthorRepository(IConnectionManager connectionManager) : base(connectionManager) { }

    }
}
