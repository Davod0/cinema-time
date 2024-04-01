namespace Cinema.Core;

public interface IReservationRepository
{
    public Task<Reservation> AddReservationAsync(Reservation r);
    public Task<List<Reservation>> GetAllReservationsAsync();
    public Task<List<Reservation>> GetReservationsForCinemaViewingAsync(int cinemaViewingId);
    public Task<Reservation> DeleteReservationAsync(int id);
    public Task<Reservation> GetReservationById(int id);
}
