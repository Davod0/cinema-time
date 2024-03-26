
namespace Cinema.Core;


public class MovieService
{
    IMovieRepository _iMovieRepo;
    public MovieService(IMovieRepository iMovieRepo)
    {
        _iMovieRepo = iMovieRepo;
    }

    public async Task<int> AddMovieAndGetIdAsync(Movie m)
    {
        return await _iMovieRepo.AddMovieAndGetIdAsync(m);
    }

    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await _iMovieRepo.GetMoviesAsync();
    }


}