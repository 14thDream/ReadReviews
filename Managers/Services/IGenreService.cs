using Models;

namespace Managers.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        Genre? GetGenreById(int id);
        void AddGenre(Genre genre);
        Genre? UpdateGenre(int id, Genre genre);
        bool DeleteGenre(int id);
    }
}
