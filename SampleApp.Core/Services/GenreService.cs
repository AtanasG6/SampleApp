using SampleApp.Core.Interfaces;
using SampleApp.Core.Projections.Genres;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;
using SampleApp.Data.Sorting;
using System.Linq.Expressions;

namespace SampleApp.Core.Services
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IRepository<Genre> repository) : base(repository)
        {
        }

        public IEnumerable<GenreGeneralInfoProjection> GetAll()
        {
            var nameOrderClause = new OrderClause<Genre>
            {
                Expression = g => g.Name,
                // IsAscending = true
            };

            return this.Repository.GetMany(
                _ => true,
                this.GetGeneralInfoProjection(),
                new[] { nameOrderClause }
             );
        }

        public GenreGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                this.GetGeneralInfoProjection()
            );
        }

        public IEnumerable<GenreMinifiedProjection> GetAllMinified()
        {
            var nameOrderClause = new OrderClause<Genre>
            {
                Expression = g => g.Name,
                // IsAscending = true
            };

            return this.Repository.GetMany(
                _ => true,
                this.GetMinifiedProjection(),
                new[] { nameOrderClause }
            );
        }

        public GenreMinifiedProjection? GetOneMinified(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                this.GetMinifiedProjection()
            );
        }

        private Expression<Func<Genre, GenreGeneralInfoProjection>> GetGeneralInfoProjection()
        {
            return g => new GenreGeneralInfoProjection
            {
                Id = g.Id,
                Name = g.Name,
                SongsCount = g.Songs.LongCount()
            };
        }

        private Expression<Func<Genre, GenreMinifiedProjection>> GetMinifiedProjection()
        {
            return g => new GenreMinifiedProjection
            {
                Id = g.Id,
                Name = g.Name
            };
        }
    }
}
