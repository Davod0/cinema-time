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

