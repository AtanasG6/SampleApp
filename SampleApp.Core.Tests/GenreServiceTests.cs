using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleApp.Core.Services;
using SampleApp.Data;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace SampleApp.Core.Tests
{
    public class GenreServiceTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public GenreServiceTests(ITestOutputHelper outputHelper)
        {
            this._outputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
        }

        [Fact]
        public void CreateGenreShouldWorkCorrectly()
        {
            // Arrange
            var dbContext = InitializeDatabase("Server=.;Database=music_test_1;Integrated Security=True;TrustServerCertificate=True");
            var repository = new Repository<Genre>(dbContext);
            var service = new GenreService(repository);

            // Act
            var allGenres = service.GetAll();

            // Assert
            Assert.NotNull(allGenres);
            Assert.Empty(allGenres);
        }

        private SampleDbContext InitializeDatabase(string connectionString)
        {
            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

            optionsBuilder.LogTo(this._outputHelper.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseSqlServer(connectionString);

            SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);
            // dbContext.Database.EnsureDeleted();
            // dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            return dbContext;
        }
    }
}
