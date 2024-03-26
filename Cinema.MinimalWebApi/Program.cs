namespace Cinema.MinimalWebApi;
using Cinema.Infrastructure;
using Cinema.Core;
using Microsoft.EntityFrameworkCore;
using Swashbuckle;
using Microsoft.AspNetCore.Http.HttpResults;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DbContextInfrastructure.AddDbContext(builder.Configuration, builder.Services);
        builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/minimalApi/movie", async (MovieService _ms) => await _ms.GetAllMoviesAsync());

        app.MapGet("/minimalApi/postMovie", async (MovieService _ms, Movie m) =>
        {
            if (await _ms.AddMovieAsync(m) != null)
            {
                return Results.Created("/minimalApi/postMovie", m);
            }
            return Results.BadRequest();
        });

        app.MapGet("/minimalApi/deleteMovie", async (MovieService _ms, Movie m) =>
        {
            if (await _ms.DeleteMovieAsync(m) != null)
            {
                return Results.Ok(m);
            }
            return Results.BadRequest(); ;

        });

        app.Run();
    }
}



