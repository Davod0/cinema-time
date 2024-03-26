namespace Cinema.Infrastructure;

using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Core;

public class MovieRepository : IMovieRepository
{
    // Här kontaktas databasen alltså CinemaDbContext för att lägga data i databsen.
    public Task<int> AddMovieAndGetIdAsync(Movie m)
    {
        throw new NotImplementedException();
    }

    public Task<List<Movie>> GetMoviesAsync()
    {
        throw new NotImplementedException();
    }
}