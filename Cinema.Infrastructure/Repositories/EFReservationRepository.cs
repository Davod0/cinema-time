namespace Cinema.Infrastructure;
using Cinema.Core;
using Microsoft.EntityFrameworkCore;

public class EFReservationRepository : IReservationRepository
{
    private readonly CinemaDbContext _dB;
    public EFReservationRepository(CinemaDbContext cinemaDbContext)
    {
        _dB = cinemaDbContext;
    }

    public async Task<Reservation> AddReservationAsync(Reservation r)
    {
        _dB.Reservations.AddAsync(r);
        await _dB.SaveChangesAsync();
        return r;
    }

    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        return await _dB.Reservations.ToListAsync();
    }

    public async Task<List<Reservation>> GetReservationsForCinemaViewingAsync(int cinemaViewingId)
    {
        CinemaViewing? cv = await _dB.CinemaViewings.FindAsync(cinemaViewingId);
        if (cv != null)
        {
            return await _dB.Reservations.Where(r => r.CinemaViewingId == cinemaViewingId).ToListAsync();
        }
        return null;
    }

    public async Task<Reservation> DeleteReservationAsync(int id)
    {
        Reservation? r = _dB.Reservations.Where(res => res.Id == id).FirstOrDefault();
        if (r != null)
        {
            _dB.Reservations.Remove(r);
            await _dB.SaveChangesAsync();
            return r;
        }
        return null;
    }

    public async Task<Reservation> GetReservationById(int id)
    {
        return await _dB.Reservations.FindAsync(id);
    }

    public async Task<bool> SetReservationCodeToUsedAsync(int reservationId)
    {
        Reservation? r = await _dB.Reservations.FindAsync(reservationId);
        if (r != null)
        {
            r.UsedRservationCode = true;
            await _dB.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
