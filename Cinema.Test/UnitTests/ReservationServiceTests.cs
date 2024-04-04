namespace Cinema.Test;
using Cinema.Core;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

public class ReservationServiceTests
{
    [Fact]
    public async Task AddReservationAsyncc_ShouldAddReservationAndReturnAddedReservation()
    {
        // Arrange
        Reservation res = new Reservation() { Id = 1, CinemaViewingId = 2, Quantity = 3 };
        var mockReservationRepo = new Mock<IReservationRepository>();
        mockReservationRepo.Setup(repo => repo.AddReservationAsync(res)).ReturnsAsync(res);

        List<CinemaViewing> listOfCv = new() { new CinemaViewing { Id = 2, PlaceQuantity = 10 } };
        var mockCinemaViewingRepo = new Mock<ICinemaViewingRepository>();
        mockCinemaViewingRepo.Setup(repo => repo.GetAllCinemaViewingsAsync()).ReturnsAsync(listOfCv);

        // Act
        ReservationService resService = new(mockReservationRepo.Object, mockCinemaViewingRepo.Object);

        var addedReservation = resService.AddReservationAsync(res);

        // Assert
        Assert.NotNull(addedReservation);
        Assert.Equal(res.Id, addedReservation.Id);
        Assert.Equal(res.CinemaViewingId, addedReservation.Result.CinemaViewingId);
        Assert.Equal(7, addedReservation.Result.CinemaViewing.PlaceQuantity);
    }
}

