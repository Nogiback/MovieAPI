using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTOs;
using MovieAPI.Models;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/movies?pageNumber=1&pageSize=5
        [HttpGet]
        public ActionResult<PaginatedResponse<MovieReadDTO>> GetMovies(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            // Validate pagination parameters
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 5;

            // Get paginated data from repository
            var (movies, totalCount) = _movieRepository.GetPaginated(pageNumber, pageSize);

            // Calculate total pages
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Map to DTOs
            var movieDtos = movies.Select(m => new MovieReadDTO
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                Genre = m.Genre,
                ImgUrl = m.ImgUrl
            }).ToList();

            // Create paginated response
            var response = new PaginatedResponse<MovieReadDTO>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages,
                Data = movieDtos
            };

            return Ok(response);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public ActionResult<MovieReadDTO> GetMovie(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                return NotFound(new { message = $"Movie with ID {id} not found" });
            }

            var movieDto = new MovieReadDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                ImgUrl = movie.ImgUrl
            };

            return Ok(movieDto);
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult<MovieReadDTO> CreateMovie([FromBody] MovieCreateDTO movieCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = new Movie
            {
                Title = movieCreateDto.Title,
                ReleaseYear = movieCreateDto.ReleaseYear,
                Genre = movieCreateDto.Genre,
                ImgUrl = movieCreateDto.ImgUrl
            };

            _movieRepository.Add(movie);
            _movieRepository.Save();

            var movieReadDto = new MovieReadDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                ImgUrl = movie.ImgUrl
            };

            return CreatedAtAction(
                nameof(GetMovie),
                new { id = movie.Id },
                movieReadDto);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieUpdateDTO movieUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                return NotFound(new { message = $"Movie with ID {id} not found" });
            }

            movie.Title = movieUpdateDto.Title;
            movie.ReleaseYear = movieUpdateDto.ReleaseYear;
            movie.Genre = movieUpdateDto.Genre;
            movie.ImgUrl = movieUpdateDto.ImgUrl;

            _movieRepository.Update(movie);
            _movieRepository.Save();

            return NoContent();
        }

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                return NotFound(new { message = $"Movie with ID {id} not found" });
            }

            _movieRepository.Delete(id);
            _movieRepository.Save();

            return NoContent();
        }
    }
}