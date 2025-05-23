namespace Cinema.IntegrationsTests;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Cinema.Infrastructure;

internal class CinemaWebApplicationFactory : WebApplicationFactory<Cinema.WebApi.Program>
{
    override protected void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices
        (services =>
        {
            //Remove the existing DbContextOptions
            services.RemoveAll(typeof(DbContextOptions<CinemaDbContext>));

            //Register a new DbContext that will use our test connection string
            services.AddSqlite<CinemaDbContext>("Data Source=../database-test.db");

            CinemaDbContext dBContext = CreateDbContext(services);
            dBContext.Database.EnsureDeleted();
            dBContext.Database.EnsureCreated();
        });
    }

    // One method to create the DbContext
    // This method is used to create a new scope and get the DbContext
    private static CinemaDbContext CreateDbContext(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var scope = serviceProvider.CreateScope();
        var dBContext = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
        return dBContext;
    }
}