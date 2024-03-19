namespace Cinema.Infrastructure;

using Cinema.Core;
using Microsoft.EntityFrameworkCore;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions opts) : base(opts) { }

    public DbSet<CinemaViewing> CinemaViewings { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Salon> Salons { get; set; }
}


/*
    I första alternativet ( public CinemaDbContext(DbContextOptions opts) : base(opts){ } ) 
    låter vi att sorten av databas (UseSqlite, UseMemoryCache...) bestämms från ett annat ställe i detta fall i
    klassen ..... där skappas DbContextOptionsBuilder objektet och skickas vidare till CinemaDbContext som skappar databasen.

    Men man kan ha ett annat alternativ också för att skappa databasen och i detta altenativ bestämms sorten av databasen direkt
    i klassen CinemaDbContext{}
    // public CinemaDbContext(DbContextOptionsBuilder opts)
    // {
    //     opts.UseSqlite("Data Source= database.db");
    // }
*/