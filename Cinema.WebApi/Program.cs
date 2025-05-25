namespace Cinema.WebApi;

using Cinema.Core;
using Cinema.Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DbContextInfrastructure.AddDbContext(builder.Configuration, builder.Services);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<SalonService>();
        builder.Services.AddScoped<ISalonRepository, EFSalonRepository>();
        builder.Services.AddScoped<MovieService>();
        builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
        builder.Services.AddScoped<CinemaViewingService>();
        builder.Services.AddScoped<ICinemaViewingRepository, EFCinemaViewingRepository>();
        builder.Services.AddScoped<ReservationService>();
        builder.Services.AddScoped<IReservationRepository, EFReservationRepository>();
        builder.Services.AddControllers();
        builder.Services.AddAuthentication().AddJwtBearer();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        builder.Services.AddAuthorization();
        var app = builder.Build();
        app.UseCors("AllowAll");
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.MapControllers();
        app.Run();
    }
}

