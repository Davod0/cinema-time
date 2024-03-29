namespace Cinema.Core;

public interface ICinemaViewingRepository
{
    public Task<CinemaViewing> AddCinemaViewingAsync(CinemaViewing cv);
    public Task<List<CinemaViewing>> GetAllCinemaViewingsAsync();
    public Task<CinemaViewing> DeleteCinemaViewingAsync(int id);
}