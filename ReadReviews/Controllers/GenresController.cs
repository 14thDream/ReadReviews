using Managers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ReadReviews.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = _genreService.GetAllGenres();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> GetGenreById(int id)
        {
            return _genreService.GetGenreById(id) switch
            {
                null => NotFound(),
                Genre genre => Ok(genre)
            };
        }

        [HttpPost]
        public ActionResult AddGenre(Genre genre)
        {
            _genreService.AddGenre(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, Genre genre)
        {
            return _genreService.UpdateGenre(id, genre) switch
            {
                null => NotFound(),
                _ => NoContent()
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            return _genreService.DeleteGenre(id) ? NoContent() : NotFound();
        }
    }
}
