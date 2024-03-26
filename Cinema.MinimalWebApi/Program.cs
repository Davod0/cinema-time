namespace Cinema.MinimalWebApi;
using Cinema.Infrastructure;
using Cinema.Core;
using Microsoft.EntityFrameworkCore;
using Swashbuckle;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DbContextInfrastructure.AddDbContext(builder.Configuration, builder.Services);
        builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        app.MapGet("/movie", () => "Hello World!");

        app.Run();
    }
}

