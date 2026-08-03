using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using SampleApp.Core.Interfaces;
using SampleApp.Core.Services;
using SampleApp.Data;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;
using System.Reflection;

namespace SampleApp.Web.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            RegisterDbContext(builder);
            RegisteredServices(builder);
            RegisterAutoMapper(builder);

            // TODO: Add registrations for repositories and services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SampleDbContext>(options =>
            {
                // TODO: Read from appsettings.json

                const string connectionString = "Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True";

#if DEBUG
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

                options.UseSqlServer(connectionString);
            });
        }
        private static void RegisteredServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository<Genre>, Repository<Genre>>();
            builder.Services.AddScoped<IGenreService, GenreService>();

            builder.Services.AddScoped<IRepository<Song>, Repository<Song>>();
            builder.Services.AddScoped<ISongService, SongService>();
        }

        private static void RegisterAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        }
    }
}
