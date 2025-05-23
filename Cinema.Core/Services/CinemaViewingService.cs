namespace Cinema.Core;

public class CinemaViewingService
{
    private readonly ICinemaViewingRepository _repo;
    private readonly IMovieRepository _movieRepo;
    public CinemaViewingService(ICinemaViewingRepository cinemaViewingRepository, IMovieRepository movieRepository)
    {
        _repo = cinemaViewingRepository;
        _movieRepo = movieRepository;
    }

    public async Task<CinemaViewing> AddCinemaViewingAsync(CinemaViewing cv)
    {
        if (cv != null)
        {
            List<CinemaViewing> list = await _repo.GetAllCinemaViewingsAsync();
            var isUniqueTimeAndDate = !list.Any(_cv => _cv.SalonId == cv.SalonId && _cv.TimeAndDate == cv.TimeAndDate);
            var numberOfCinemaViewingsWithSameMovieId = list.Count(_cv => _cv.MovieId == cv.MovieId);

            if (isUniqueTimeAndDate && numberOfCinemaViewingsWithSameMovieId <= 2)
            {
                Movie movie = await _movieRepo.GetMovieByIdAsync(cv.MovieId);
                cv.Movie = movie;
                if (await _repo.AddCinemaViewingAsync(cv) != null)
                {
                    return cv;
                }
            }
        }
        return null;
    }

    public async Task<List<CinemaViewing>> GetAllCinemaViewingsAsync()
    {
        List<CinemaViewing> cinemaViewing = await _repo.GetAllCinemaViewingsAsync();
        if (cinemaViewing != null)
        {
            return cinemaViewing;
        }
        return null;
    }

    public async Task<CinemaViewing> DeleteCinemaViewingAsync(int id)
    {
        if (id != null)
        {
            CinemaViewing cv = await _repo.DeleteCinemaViewingAsync(id);
            if (cv != null)
            {
                return cv;
            }
        }
        return null;
    }

    public async Task<List<CinemaViewing>> GetAllUpcomingCinemaViewingsAsync()
    {
        List<CinemaViewing> cinemaViewings = await _repo.GetAllCinemaViewingsAsync();
        // var upcomingCinemaViewings = cinemaViewings.Where(cv => cv.TimeAndDate > DateTime.Now).ToList();
        var upcomingCinemaViewings = cinemaViewings.ToList();
        if (upcomingCinemaViewings != null)
        {
            return upcomingCinemaViewings;
        }
        return null;
    }

}


