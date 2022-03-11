namespace DataAccess.Repositories.Books.Dtos
{
    public class CreateBookRequest
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }
}