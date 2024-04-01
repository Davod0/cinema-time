namespace Cinema.Infrastructure;
using Cinema.Core;
using Microsoft.EntityFrameworkCore;

public class EFCinemaViewingRepository : ICinemaViewingRepository
{
    private readonly CinemaDbContext _dB;
    public EFCinemaViewingRepository(CinemaDbContext cinemaDbContext)
    {
        _dB = cinemaDbContext;
    }
    public async Task<CinemaViewing> AddCinemaViewingAsync(CinemaViewing cv)
    {
        _dB.CinemaViewings.AddAsync(cv);
        await _dB.SaveChangesAsync();
        return cv;
    }

    public async Task<CinemaViewing> DeleteCinemaViewingAsync(int id)
    {
        CinemaViewing? cv = _dB.CinemaViewings.Where(CinemaViewing => CinemaViewing.Id == id).FirstOrDefault();
        if (cv != null)
        {
            _dB.CinemaViewings.Remove(cv);
            await _dB.SaveChangesAsync();
            return cv;
        }
        return null;
    }

    public async Task<List<CinemaViewing>> GetAllCinemaViewingsAsync()
    {
        return await _dB.CinemaViewings.Include(cv => cv.Movie).ToListAsync();
    }
}