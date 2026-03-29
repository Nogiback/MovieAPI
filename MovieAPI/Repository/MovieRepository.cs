using MovieAPI.Models;
using MovieAPI.Data;

namespace MovieAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public MovieDbContext _context { get; }

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(Movie obj)
        {
            _context.Movies.Add(obj);
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
        }

         public void Update(Movie obj)
        {
            _context.Movies.Update(obj);
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        // Adding the pagination method
        public (List<Movie> movies, int totalCount) GetPaginated(int pageNumber, int pageSize)
        {
            var totalCount = _context.Movies.Count();

            var movies = _context.Movies
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (movies, totalCount);
        }
    }
}