using DataAccess.Contexts;
using DataAccess.Repositories.Authors;
using DataAccess.Repositories.Books;
using DataAccess.Repositories.Books.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDataAccessContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookController(
            IDataAccessContext dbContext,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository)
        {
            _context = dbContext;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookRepository.GetBook(id);
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookRequest request)
        {
            var author = await _authorRepository.GetAuthor(request.AuthorId);

            if(author is null)
            {
                return BadRequest("No Author with this Id.");
            }

            var id = await _bookRepository.AddBook(request);

            var book = await _bookRepository.GetBook(id);

            await _context.Commit();

            return Ok(id);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
