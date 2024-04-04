namespace Cinema.Test;
using Cinema.Core;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

public class MovieServiceTest
{
    [Fact]
    public async void GetMovieByIdAsync_ShouldReturnMovieById()
    {
        // Arrange
        Movie m = new Movie() { Id = 1, Title = "The Matrix" };
        var mockMovieRepo = new Mock<IMovieRepository>();
        mockMovieRepo.Setup(repo => repo.GetMovieByIdAsync(m.Id)).ReturnsAsync(m);

        // Act
        MovieService movieService = new(mockMovieRepo.Object);
        Movie movie = await movieService.GetMovieByIdAsync(m.Id);

        // Assert
        Assert.NotNull(movie);
        Assert.Equal("The Matrix", movie.Title);
    }


    [Fact]
    public void GetAllMoviesAsync_ShouldReturnAllMovies()
    {
        // Arrange
        FakeMovieRepository FmovieRepo = new();
        MovieService movieService = new(FmovieRepo);

        // Act
        var movies = movieService.GetAllMoviesAsync();

        // Assert
        Assert.NotNull(movies);
        Assert.Equal(3, movies.Result.Count);

    }

    [Fact]
    public void AddMovieAsync_ShouldAddMovie()
    {
        // Arrange
        FakeMovieRepository FmovieRepo = new();
        MovieService movieService = new(FmovieRepo);
        Movie m = new Movie()
        {
            Id = 1,
            Title = "The Matrix",
            Description = "Description 1",
            Genre = "Genre 1",
            AgeLimit = 10,
            Language = "Language 1",
            UnderText = "UnderText 1",
            Actors = new List<string>() { "Actor 1" },
            Direction = new List<string>() { "Direction 1" },
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Time = TimeOnly.FromDateTime(DateTime.Now),
            ImageUrl = "ImageUrl 1"
        };

        // Act
        var addedMovie = movieService.AddMovieAsync(m);

        // Assert
        Assert.NotNull(addedMovie);
        Assert.Equal("The Matrix", addedMovie.Result.Title);
    }


}

public class FakeMovieRepository : IMovieRepository
{
    public Task<Movie> AddMovieAsync(Movie m)
    {
        return Task.FromResult(m);
    }

    public Task<Movie> DeleteMovieAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Movie>> GetAllMoviesAsync()
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie(){Id = 1, Title = "Movie 1"},
            new Movie(){Id = 2, Title = "Movie 2"},
            new Movie(){Id = 3, Title = "Movie 3"}
        };
        return Task.FromResult(movies);
    }

    public Task<Movie> GetMovieByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}