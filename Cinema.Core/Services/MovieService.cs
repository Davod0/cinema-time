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
            var addedM = await _iMovieRepo.AddMovieAsync(m);
            if (addedM != null)
            {
                return m;
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

    public async Task<Movie> GetMovieById(int id)
    {
        Movie m = await _iMovieRepo.GetMovieById(id);
        if (m != null)
        {
            return m;
        }
        return null;
    }
}


