namespace Cinema.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DbContextInfrastructure
{
    public static void AddDbContext(IConfiguration configuration, IServiceCollection services)
    {
        bool useOnlyInMemoryDatabase = false;
        if (configuration["UseInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseInMemoryDatabase"]!);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<CinemaDbContext>(opt => opt.UseInMemoryDatabase("Cinema.db"));
        }
        else
        {
            services.AddDbContext<CinemaDbContext>(opt => opt.UseSqlite("Data Source=../Cinema.Infrastructure/database.db"));
        }
    }
}



