namespace Cinema.WebApi;

using Cinema.Core;
using Cinema.Infrastructure;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DbContextInfrastructure.AddDbContext(builder.Configuration, builder.Services);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<SalonService>();
        builder.Services.AddScoped<ISalonRepository, EFSalonRepository>();
        builder.Services.AddControllers();
        var app = builder.Build();
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

