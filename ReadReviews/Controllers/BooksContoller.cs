using Managers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ReadReviews.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            return _bookService.GetBookById(id) switch
            {
                null => NotFound(),
                Book book => Ok(book)
            };
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            return _bookService.UpdateBook(id, book) switch
            {
                null => NotFound(),
                _ => NoContent()
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            return _bookService.DeleteBook(id) ? NoContent() : NotFound();
        }
    }
}
