namespace Cinema.Core;

public interface IMovieService
{
    public Task<Movie> AddMovieAsync(Movie m);
    public Task<List<Movie>> GetAllMoviesAsync();
    public Task<Movie> DeleteMovieAsync(int id);
}

