using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer("Server=.;Database=MusicDb;Integrated Security=True;TrustServerCertificate=True");

            using SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Song song1 = new Song { Name = "Bohemian Rhapsody" };
            dbContext.Songs.Add(song1);

            dbContext.SaveChanges();
        }
    }
}
