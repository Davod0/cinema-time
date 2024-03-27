namespace Cinema.Core;

public class SalonService : ISalonService
{
    private readonly ISalonRepository _salonRepo;
    public SalonService(ISalonRepository iSalonRepository)
    {
        _salonRepo = iSalonRepository;
    }

    public async Task<Salon> AddSalonAsync(Salon s)
    {
        if (s != null)
        {
            if (await _salonRepo.AddSalonAsync(s) != null)
            {
                return s;
            }
        }
        return null;
    }
    public async Task<List<Salon>> GetAllSalonsAsync()
    {
        List<Salon> salons = await _salonRepo.GetAllSalonsAsync();
        if (salons != null)
        {
            return salons;
        }
        return null;
    }

    public async Task<Salon> DeleteSalonAsync(int id)
    {
        if (id != 0)
        {
            Salon deleteSalon = await _salonRepo.DeleteSalonAsync(id);
            if (deleteSalon != null)
            {
                return deleteSalon;
            }
        }
        return null;
    }




}