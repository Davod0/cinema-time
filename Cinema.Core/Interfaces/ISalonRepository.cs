namespace Cinema.Core;

public interface ISalonRepository
{
    public Task<Salon> AddSalonAsync(Salon s);
    public Task<List<Salon>> GetAllSalonsAsync();
    public Task<Salon> DeleteSalonAsync(int id);
}