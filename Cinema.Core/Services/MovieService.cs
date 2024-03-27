namespace Cinema.Core;

public class MovieService
{
    IMovieRepository _iMovieRepo;
    public MovieService(IMovieRepository iMovieRepo)
    {
        _iMovieRepo = iMovieRepo;
    }

    public async Task<Movie> AddMovieAsync(Movie m)
    {
        if (m != null && m.Title.Length >= 2)
        {
            await _iMovieRepo.AddMovieAsync(m);
            if (await _iMovieRepo.FindMovieAsync(m) != null)
            {
                return m;
            }
            else
            {
                return null;
            }
        }
        return null;
    }
    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        List<Movie> movies = await _iMovieRepo.GetAllMoviesAsync();
        if (movies != null)
        {
            return movies;
        }
        return null;
    }

    public async Task<Movie> DeleteMovieAsync(int id)
    {
        if (id != null)
        {
            Movie deletedMovie = await _iMovieRepo.DeleteMovieAsync(id);
            if (deletedMovie != null)
            {
                return deletedMovie;
            }
        }
        return null;
    }
}


