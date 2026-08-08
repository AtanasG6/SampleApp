using SampleApp.Core.Interfaces;
using SampleApp.Core.Projections.Artists;
using SampleApp.Core.Projections.Genres;
using SampleApp.Core.Projections.Songs;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;
using SampleApp.Data.Sorting;
using System.Linq.Expressions;

namespace SampleApp.Core.Services
{
    public class SongService : BaseService<Song>, ISongService
    {
        public SongService(IRepository<Song> repository) : base(repository)
        {
        }

        public IEnumerable<SongGeneralInfoProjection> GetAll()
        {
            var nameOrderClause = new OrderClause<Song>() { Expression = s => s.Name };
            var artistOrderClause = new OrderClause<Song>() { Expression = s => s.Artist.Nickname };

            return this.Repository.GetMany(
                _ => true,
                this.GetGeneralInfoProjection(),
                new[] { nameOrderClause, artistOrderClause }
            );
        }

        public SongGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                s => s.Id == id,
                this.GetGeneralInfoProjection()
            );
        }

        public SongEditProjection? GetOneEdit(Guid id)
        {
            return this.Repository.Get(
                s => s.Id == id,
                s => new SongEditProjection
                {
                    Id = s.Id,
                    Name = s.Name,
                    ArtistId = s.ArtistId,
                    GenreIds = s.Genres.Select(g => g.Id)
                }
            );
        }

        public SongMinifiedProjection? GetOneMinified(Guid id)
        {
            return this.Repository.Get(
                s => s.Id == id,
                s => new SongMinifiedProjection
                {
                    Id = s.Id,
                    Name = s.Name
                }
            );
        }

        private Expression<Func<Song, SongGeneralInfoProjection>> GetGeneralInfoProjection()
        {
            return s => new SongGeneralInfoProjection
            {
                Id = s.Id,
                Name = s.Name,
                Artist = new ArtistMinifiedProjection
                {
                    Id = s.Artist.Id,
                    Nickname = s.Artist.Nickname
                },
                Genres = s.Genres.Select(g => new GenreMinifiedProjection
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            };
        }
    }
}
