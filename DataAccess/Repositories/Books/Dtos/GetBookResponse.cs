namespace DataAccess.Repositories.Books.Dtos
{
    public class GetBookResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int AuthorName { get; set; }
    }
}