using SampleApp.Core.Interfaces;
using SampleApp.Core.Projections.Artists;
using SampleApp.Core.Projections.Songs;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;
using SampleApp.Data.Sorting;

namespace SampleApp.Core.Services
{
    public class ArtistService : BaseService<Artist>, IArtistService
    {
        public ArtistService(IRepository<Artist> repository) : base(repository)
        {
        }

        public IEnumerable<ArtistGeneralInfoProjection> GetAll()
        {
            var nicknameOrderClause = new OrderClause<Artist> { Expression = a => a.Nickname };

            return this.Repository.GetMany(
                _ => true,
                a => new ArtistGeneralInfoProjection
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Nickname = a.Nickname,
                    Songs = a.Songs
                        .Select(s => new SongMinifiedProjection
                        {
                            Id = s.Id,
                            Name = s.Name
                        })
                        .OrderBy(s => s.Name)
                        .ToArray()
                },
                new[] { nicknameOrderClause });
        }
    }
}
