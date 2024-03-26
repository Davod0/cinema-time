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
    public async Task<List<Movie>> GetAllMoviesAsync(Movie m)
    {
        List<Movie> movies = await _iMovieRepo.GetAllMoviesAsync();
        if (movies != null)
        {
            return movies;
        }
        return null;
    }

    public async Task<Movie> DeleteMovieAsync(Movie m)
    {
        if (m != null)
        {
            await _iMovieRepo.DeleteMovieAsync(m);
            if (_iMovieRepo.FindMovieAsync(m) == null)
            {
                return m;
            }
        }
        return null;
    }
}


// public async Task<Movie> AddMovieAsync(Movie m)
// {
//     if (m != null && m.Title.Length >= 2)
//     {
//         await _iMovieRepo.AddMovieAsync(m);
//         if (m.Id != 0)
//         {
//             return m;
//         }
//         else
//         {
//             return null;
//         }
//     }
//     return null;
// }