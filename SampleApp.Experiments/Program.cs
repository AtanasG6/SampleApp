using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleApp.Data;
using SampleApp.Data.Models;

namespace SampleApp.Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new
                DbContextOptionsBuilder<SampleDbContext>();
            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseSqlServer("Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True");

            using SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Song song1 = new Song { Name = "Bohemian Rhapsody" };
            dbContext.Songs.Add(song1);

            var addedEntities = dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .ToList();

            foreach (var entry in addedEntities)
            {
                Console.WriteLine($"Entity of type {entry.Entity.GetType().Name} is in Added state.");
            }

            dbContext.SaveChanges();

            Console.WriteLine(song1.Id);
        }
    }
}
