using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private static List<Library> books = new List<Library>
        {
            new Library
            {   ISBN = 1,
                Title = "First",
                Genre ="Fantasy",
                Description = "It's my life",
                Author = "Jake Styart",
                TakeTime = DateTime.Now,
                ReturnTime = new DateTime(2024, 12, 12)
            },

            new Library
            {   ISBN = 2,
                Title = "Second",
                Genre ="Fantasy",
                Description = "It's my life",
                Author = "Jake Styart",
                TakeTime = DateTime.Now,
                ReturnTime = new DateTime(2024, 12, 12)
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Library>>> GetAllBooks()
        {
            return Ok(books);
        }

        [HttpGet("isbn")]
        public async Task<ActionResult<Library>> GetSingleBook(int isbn)
        {
            var book = books.Find(x => x.ISBN == isbn);

            if (book == null)
                return NotFound("Book doesn't exist.");

            return Ok(book);
        }

        [HttpPost]

        public async Task<ActionResult<List<Library>>> AddBook(Library book)
        {

            books.Add(book);
            return Ok(books);
        }

        [HttpPut("isbn")]
        public async Task<ActionResult<List<Library>>> UpdateBook(int isbn, Library request)
        {
            var book = books.Find(x => x.ISBN == isbn);

            if (book == null)
                return NotFound("Book doesn't exist.");

            book.Title = request.Title;
            book.Genre = request.Genre;
            book.Author = request.Author;
            book.Description = request.Description;
            book.TakeTime = request.TakeTime;
            book.ReturnTime = request.ReturnTime;

            return Ok(book);
        }

        [HttpDelete("isbn")]
        public async Task<ActionResult<Library>> DeleteBook(int isbn)
        {
            var book = books.Find(x => x.ISBN == isbn);

            if (book == null)
                return NotFound("Book doesn't exist.");

            books.Remove(book);

            return Ok(book);
        }
    }
}
