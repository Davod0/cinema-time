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
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGet("/minimalApi/movie", async (IMovieRepository _repo) => await _repo.GetAllMoviesAsync());
        app.MapPost("/minimalApi/postMovie", async (IMovieRepository _repo, Movie m) =>
        {
            if (await _repo.AddMovieAsync(m) != null)
            {
                return Results.Created("/minimalApi/postMovie", m);
            }
            return Results.BadRequest();
        });
        app.MapDelete("/minimalApi/deleteMovie", async (IMovieRepository _repo, int id) =>
        {

            if (await _repo.DeleteMovieAsync(id) != null)
            {
                return Results.Ok();
            }
            return Results.BadRequest(); ;

        });

        app.Run();
    }
}



