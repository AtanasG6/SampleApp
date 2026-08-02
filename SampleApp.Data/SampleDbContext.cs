using Microsoft.EntityFrameworkCore;
using SampleApp.Data.Models;

namespace SampleApp.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public SampleDbContext()
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        // public DbSet<Genre> Genres { get; set; }
    }
}
