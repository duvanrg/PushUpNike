using System.Reflection;
using API.Extensions;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.ConfigureCors();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
        builder.Services.AddAplicationServices();
        builder.Services.ConfigureRateLimiting();

        builder.Services.AddDbContext<ApiContext>(options =>
        {
            string connectionString = builder.Configuration.GetConnectionString("ConexMySql");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("MyCorsPolicy");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}