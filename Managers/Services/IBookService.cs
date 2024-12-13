using Models;

namespace Managers.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        Book? UpdateBook(int id, Book book);
        bool DeleteBook(int id);
    }
}
