namespace Cinema.Infrastructure;

using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Core;
using Microsoft.EntityFrameworkCore;

public class EFSalonRepository : ISalonRepository
{
    private readonly CinemaDbContext _dB;

    public EFSalonRepository(CinemaDbContext cinemaDbContext)
    {
        _dB = cinemaDbContext;
    }
    public async Task<Salon> AddSalonAsync(Salon s)
    {
        if (s != null)
        {
            _dB.Salons.AddAsync(s);
            await _dB.SaveChangesAsync();
            return s;
        }
        return null;
    }

    public async Task<Salon> DeleteSalonAsync(int id)
    {
        Salon? s = _dB.Salons.Where(s => s.Id == id).FirstOrDefault();
        if (s != null)
        {
            _dB.Salons.Remove(s);
            await _dB.SaveChangesAsync();
            return s;
        }
        return null;
    }

    public Task<List<Salon>> GetAllSalonsAsync()
    {
        return _dB.Salons.ToListAsync();
    }
}