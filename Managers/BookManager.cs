using Managers.Context;
using Managers.Services;
using Models;

namespace Managers
{
    public class BookManager : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks() => _context.Books.ToList();
        public Book? GetBookById(int id) => _context.Books.Find(id);

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book? UpdateBook(int id, Book book)
        {
            var existingBook = GetBookById(id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook = book;
            _context.SaveChanges();

            return existingBook;
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return true;
        }
    }
}
