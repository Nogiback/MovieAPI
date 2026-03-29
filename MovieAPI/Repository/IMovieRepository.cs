using MovieAPI.Models;
    
namespace MovieAPI.Repository 
{
  public interface IMovieRepository
    {
      // CRUD operations for Movie
      void Add(Movie obj);

      void Delete(int id);

      void Update(Movie obj);

      void Save();

      Movie GetById(int id);

      List<Movie> GetAll();

      // New pagination method
      (List<Movie> movies, int totalCount) GetPaginated(int page, int pageSize);
      
    }
}