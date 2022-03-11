using DataAccess.Repositories.Authors.Dtos;

namespace DataAccess.Repositories.Authors
{
    public interface IAuthorRepository
    {
        public Task<GetAuthorResponse> GetAuthor(int id);
    }
}
