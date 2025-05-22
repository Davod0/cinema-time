namespace Cinema.IntegrationsTests;

using Cinema.Core;
using System.Net.Http.Json;

public class WebApiTests
{
    [Fact]
    public async Task PostSalon_ReturnSalon()
    {
        // Arrange
        var application = new CinemaWebApplicationFactory();
        var client = application.CreateClient();
        Salon sa = new() { Id = 1, Nummber = 10, Name = "Large" };

        // Act
        var response = await client.PostAsJsonAsync("/salon", sa);

        // Assert
        response.EnsureSuccessStatusCode();
        Salon? salonResponse = await response.Content.ReadFromJsonAsync<Salon>();

        Assert.NotNull(salonResponse);
        Assert.Equal(salonResponse.Id, sa.Id);
        Assert.Equal(salonResponse.Name, sa.Name);
        Assert.Equal(salonResponse.Nummber, sa.Nummber);
    }
}
