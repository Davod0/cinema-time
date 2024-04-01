namespace Cinema.Infrastructure;

using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Core;
using Microsoft.EntityFrameworkCore;

public class EFMovieRepository : IMovieRepository
{
    private readonly CinemaDbContext _dB;
    public EFMovieRepository(CinemaDbContext cinemaDbContext)
    {
        _dB = cinemaDbContext;
    }

    public async Task<Movie> AddMovieAsync(Movie m)
    {
        _dB.Movies.AddAsync(m);
        await _dB.SaveChangesAsync();
        return m;
    }

    public async Task<Movie> DeleteMovieAsync(int id)
    {
        Movie? m = _dB.Movies.Where(movie => movie.Id == id).FirstOrDefault();
        if (m != null)
        {
            _dB.Movies.Remove(m);
            await _dB.SaveChangesAsync();
            return m;
        }
        return null;
    }

    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await _dB.Movies.ToListAsync();
    }

    public async Task<Movie> GetMovieById(int id)
    {
        return await _dB.Movies.FindAsync(id);
    }
}
