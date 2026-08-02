using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace SampleApp.Data
{
    public class SampleDbContextDesignTimeFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args)
        {
            if (args.Length == 0) throw new InvalidOperationException("Connection string must be provided as the first argument.");

            string connectionString = args[0];

            DbContextOptionsBuilder<SampleDbContext> optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();

            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);

            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);

            optionsBuilder.UseSqlServer(connectionString);

            SampleDbContext dbContext = new SampleDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
