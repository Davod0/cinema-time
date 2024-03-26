namespace Cinema.Core;

public interface IMovieRepository
{
    public Task<Movie> AddMovieAsync(Movie m);
    public Task<List<Movie>> GetAllMoviesAsync();
    public Task<Movie> DeleteMovieAsync(Movie m);
    public Task<Movie> FindMovieAsync(Movie m);
}