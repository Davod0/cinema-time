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
            services.AddDbContext<CinemaDbContext>(opt => opt.UseSqlite("Data Source=database.db"));
        }
    }
}

/*
    En enklare version av AddDbContext() metoden 

    public static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CinemaDbContext>(opt => opt.UseSqlite("Data Source=database.db"));

        // Annat alternativ____
        // services.AddDbContext<CinemaDbContext>();
    }


    ____________________________________________________________________
    Denna klass tillhandahåller hjälpmetoder 
    för att konfigurera databasanlutningen i applikationen.
    Metoden AddDbContext används i en annan projekts Program.cs-klass för att 
    avgöra vilken databas projektet kommer att använda, baserat på konfigurationsinställningarna i appsettings.json-filen

*/




