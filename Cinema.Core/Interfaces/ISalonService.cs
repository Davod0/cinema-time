namespace Cinema.Core;

public interface ISalonService
{
    public Task<Salon> AddSalonAsync(Salon s);
    public Task<List<Salon>> GetAllSalonsAsync();
    public Task<Salon> DeleteSalonAsync(int id);

}