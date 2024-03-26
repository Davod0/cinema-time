namespace Cinema.Core;

public interface IMovieRepository
{
    public Task<List<Movie>> GetMoviesAsync();
    public Task<int> AddMovieAndGetIdAsync(Movie m);
}