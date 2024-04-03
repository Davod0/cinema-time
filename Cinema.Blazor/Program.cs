namespace Cinema.Blazor;

using Cinema.Blazor.Components;
using Cinema.Infrastructure;
using Cinema.Core;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        DbContextInfrastructure.AddDbContext(builder.Configuration, builder.Services);
        builder.Services.AddScoped<SalonService>();
        builder.Services.AddScoped<ISalonRepository, EFSalonRepository>();
        builder.Services.AddScoped<MovieService>();
        builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
        builder.Services.AddScoped<CinemaViewingService>();
        builder.Services.AddScoped<ICinemaViewingRepository, EFCinemaViewingRepository>();
        builder.Services.AddScoped<ReservationService>();
        builder.Services.AddScoped<IReservationRepository, EFReservationRepository>();
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

        app.Run();
    }
}

