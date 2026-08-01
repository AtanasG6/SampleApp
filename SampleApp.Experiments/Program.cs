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

            List<string> songNames = new List<string>() { "Bohemian Rhapsody", "November Rain", "Bed of Roses" };

            const string connectionString = "Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True";

            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new
                DbContextOptionsBuilder<SampleDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
#endif

            using SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            List<Song> songsToCreate = new List<Song>();

            foreach (var name in songNames)
            {
                songsToCreate.Add(new Song { Name = name });
            }

            dbContext.Songs.AddRange(songsToCreate);


            var addedEntities = dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .ToList();

            foreach (var entry in addedEntities)
            {
                Console.WriteLine($"Entity of type {entry.Entity.GetType().Name}: {((Song)entry.Entity).Name} is in Added state.");
            }

            dbContext.SaveChanges();

            Console.WriteLine("Check your database!");
            Console.ReadLine();

            dbContext.Songs.Remove(songsToCreate[^1]);
            dbContext.SaveChanges();

            Console.WriteLine("Check your database!");
            Console.ReadLine();

            songsToCreate[0].Name = "We are the Champions";
            dbContext.Songs.Update(songsToCreate[0]);
            dbContext.SaveChanges();
        }
    }
}
