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
            const string connectionString = "Server=.;Database=music;Integrated Security=True;TrustServerCertificate=True";
            using SampleDbContext dbContext = InitializeDatabase(connectionString);

            bool continueProcessingInput = true;
            while (continueProcessingInput)
            {
                PrintMenu();
                string input = Console.ReadLine().Trim();

                if (input == "1") CreateSong(dbContext);
                else if (input == "2") GetAllSongs(dbContext);
                else if (input == "3") CreateArtist(dbContext);
                else if (input == "0") continueProcessingInput = false;
                else Console.WriteLine("Invalid input!");

                Console.WriteLine();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Create song");
            Console.WriteLine("2. Get all songs");
            Console.WriteLine("3. Create artist");
            Console.WriteLine("0. Exit");
        }


        private static SampleDbContext InitializeDatabase(string connectionString)
        {
            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseSqlServer(connectionString);

            SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private static void CreateSong(SampleDbContext dbContext)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Artist ID: ");
            Guid artistId = Guid.Parse(Console.ReadLine());

            Song songToCreate = new Song { Name = name, ArtistId = artistId };

            dbContext.Songs.Add(songToCreate);
            dbContext.SaveChanges();

            Console.WriteLine($"Song was created successfully! ID: {songToCreate.Id}");
        }

        private static void GetAllSongs(SampleDbContext dbContext)
        {
            List<Song> allSongs = dbContext.Songs.ToList();
            foreach (var song in allSongs)
                Console.WriteLine($"{song.Id}: {song.Name}");
        }

        private static void CreateArtist(SampleDbContext dbContext)
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();

            Artist artistToCreate = new Artist { FirstName = firstName, LastName = lastName, Nickname = nickname, };
            
            dbContext.Artists.Add(artistToCreate);
            dbContext.SaveChanges();

            Console.WriteLine($"Artist was created successfully! ID: {artistToCreate.Id}");
        }

        private static void Old()
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
