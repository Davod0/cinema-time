namespace Cinema.Core;

public interface IMovieRepository
{
    public Task<Movie> AddMovieAsync(Movie m);
    public Task<List<Movie>> GetAllMoviesAsync();
    public Task<Movie> DeleteMovieAsync(int id);
    public Task<Movie> GetMovieById(int id);
}