using DataAccess.Repositories.Books.Dtos;

namespace DataAccess.Repositories.Books
{
    public interface IBookRepository
    {
        public Task<int> AddBook(CreateBookRequest book);
        public Task<GetBookResponse> GetBook(int id);
    }
}