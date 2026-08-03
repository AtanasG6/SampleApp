using SampleApp.Core.Interfaces;
using SampleApp.Core.Projections.Genres;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;
using SampleApp.Data.Sorting;

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
                g => new GenreGeneralInfoProjection
                {
                    Id = g.Id,
                    Name = g.Name
                },
                new[] { nameOrderClause }
             );
        }

        public GenreGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                g => new GenreGeneralInfoProjection
                {
                    Id = g.Id,
                    Name = g.Name
                }
            );
        }
    }
}
