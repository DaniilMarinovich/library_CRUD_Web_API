using LibraryAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private DataContext _context;

        public LibraryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Library>>> GetAllBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("isbn")]
        public async Task<ActionResult<Library>> GetSingleBook(int isbn)
        {
            var book = await _context.Books.FindAsync(isbn);

            if (book == null)
                return NotFound("Book doesn't exist.");

            return Ok(book);
        }

        [HttpPost]

        public async Task<ActionResult<List<Library>>> AddBook(Library book)
        {

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut("isbn")]
        public async Task<ActionResult<List<Library>>> UpdateBook(int isbn, Library request)
        {
            var dbBook = await _context.Books.FindAsync(isbn);

            if (dbBook == null)
                return NotFound("Book doesn't exist.");

            dbBook.Title = request.Title;
            dbBook.Genre = request.Genre;
            dbBook.Author = request.Author;
            dbBook.Description = request.Description;
            dbBook.TakeTime = request.TakeTime;
            dbBook.ReturnTime = request.ReturnTime;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("isbn")]
        public async Task<ActionResult<Library>> DeleteBook(int isbn)
        {
            var book = await _context.Books.FindAsync(isbn);

            if (book == null)
                return NotFound("Book doesn't exist.");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }
    }
}
