namespace Cinema.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DbContextCreator : IDesignTimeDbContextFactory<CinemaDbContext>
{
    public CinemaDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CinemaDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlite("Data Source=database.db");
        return new CinemaDbContext(optionsBuilder.Options);
    }
}

/*
  This class is for running migrations.
  This class implements the IDesignTimeDbContextFactory interface to facilitate 
  creating an instance of the CinemaDbContext during design-time operations, such as 
  database migrations and Entity Framework Core tooling commands. 
  It configures the DbContext to use SQLite as the database engine and specifies 
  the path to the SQLite database file
*/

