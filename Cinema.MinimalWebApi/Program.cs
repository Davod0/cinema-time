namespace Cinema.MinimalWebApi;
using Cinema.Infrastructure;
using Cinema.Core;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DbContextInfrastructure.AddDbContext(builder.Services);
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddEndpointsApiExplorer();
        var app = builder.Build();

        // Här ska läggas inställningar för att skappa databasen



        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}