namespace Cinema.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

//This class is for running migrations with dotnet ef migrations add MyMigration
public class DbContextCreator : IDesignTimeDbContextFactory<CinemaDbContext>
{
    public CinemaDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CinemaDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlite("Data Source=database.db");
        return new CinemaDbContext(optionsBuilder.Options);
    }
}


