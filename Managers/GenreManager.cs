using Managers.Context;
using Managers.Services;
using Models;

namespace Managers
{
    public class GenreManager : IGenreService
    {
        private readonly ApplicationDbContext _context;

        public GenreManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres() => _context.Genres.ToList();
        public Genre? GetGenreById(int id) => _context.Genres.Find(id);

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public Genre? UpdateGenre(int id, Genre genre)
        {
            var existingGenre = GetGenreById(id);
            if (existingGenre == null)
            {
                return null;
            }

            existingGenre = genre;
            _context.SaveChanges();

            return existingGenre;
        }

        public bool DeleteGenre(int id)
        {
            var genre = GetGenreById(id);
            if (genre == null)
            {
                return false;
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return true;
        }
    }
}
