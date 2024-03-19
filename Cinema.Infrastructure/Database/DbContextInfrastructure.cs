namespace Cinema.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//This class is for using in program.cs class for creating database
public static class DbContextInfrastructure
{
    public static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CinemaDbContext>(opt => opt.UseSqlite("Data Source=database.db"));

        // Annat alternativ____
        // services.AddDbContext<CinemaDbContext>();
    }
}
