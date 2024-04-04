namespace Cinema.Test;
using Cinema.Core;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

public class CinemaViewingServiceTests
{
    [Fact]
    public async Task AddCinemaViewingAsync_ShouldNotAddCinemaViewingDueToConflictAtSameTimeSameSalon()
    {
        // Arrange
        CinemaViewing cv = new() { Id = 1, SalonId = 1, TimeAndDate = new DateTime(2024, 4, 4, 20, 30, 00), MovieId = 5 };
        var mockCinemaViewingRepo = new Mock<ICinemaViewingRepository>();
        List<CinemaViewing> listOfCv = new() { new CinemaViewing { Id = 2, SalonId = 1, TimeAndDate = new DateTime(2024, 4, 4, 20, 30, 00), MovieId = 10 } };

        mockCinemaViewingRepo.Setup(repo => repo.GetAllCinemaViewingsAsync()).ReturnsAsync(listOfCv);
        mockCinemaViewingRepo.Setup(repo => repo.AddCinemaViewingAsync(cv)).ReturnsAsync(cv);

        Movie m = new() { Id = 5 };
        var mockMovieRepo = new Mock<IMovieRepository>();
        mockMovieRepo.Setup(repo => repo.GetMovieByIdAsync(m.Id)).ReturnsAsync(m);

        // Act
        CinemaViewingService cvs = new(mockCinemaViewingRepo.Object, mockMovieRepo.Object);

        CinemaViewing addedCv = await cvs.AddCinemaViewingAsync(cv);

        // Assert
        Assert.Null(addedCv);
    }

    [Fact]
    public async Task AddCinemaViewingAsync_ShouldAddCinemaViewingAndReturnAddedCinemaViewing()
    {
        // Arrange
        CinemaViewing cv = new() { Id = 1, SalonId = 1, TimeAndDate = new DateTime(2024, 05, 04, 20, 30, 00), MovieId = 5, };
        var mockCinemaViewingRepo = new Mock<ICinemaViewingRepository>();
        List<CinemaViewing> listOfCv = new() { new CinemaViewing { Id = 2, SalonId = 1, TimeAndDate = new DateTime(2024, 05, 05, 20, 30, 00), MovieId = 10 } };

        mockCinemaViewingRepo.Setup(repo => repo.GetAllCinemaViewingsAsync()).ReturnsAsync(listOfCv);
        mockCinemaViewingRepo.Setup(repo => repo.AddCinemaViewingAsync(cv)).ReturnsAsync(cv);

        Movie m = new() { Id = 5 };
        var mockMovieRepo = new Mock<IMovieRepository>();
        mockMovieRepo.Setup(repo => repo.GetMovieByIdAsync(m.Id)).ReturnsAsync(m);

        // Act
        CinemaViewingService cvs = new(mockCinemaViewingRepo.Object, mockMovieRepo.Object);

        CinemaViewing addedCv = await cvs.AddCinemaViewingAsync(cv);

        // Assert
        Assert.NotNull(addedCv);
        Assert.Equal(cv.Id, addedCv.Id);
        Assert.Equal(cv.SalonId, addedCv.SalonId);
        Assert.Equal(cv.TimeAndDate, addedCv.TimeAndDate);
        Assert.Equal(cv.MovieId, addedCv.MovieId);
    }
}

