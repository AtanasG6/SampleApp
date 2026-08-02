using SampleApp.Core.Interfaces;
using SampleApp.Core.Projections.Songs;
using SampleApp.Data.Models;
using SampleApp.Data.Repositories;

namespace SampleApp.Core.Services
{
    public class SongService : BaseService<Song>, ISongService
    {
        public SongService(IRepository<Song> repository) : base(repository)
        {
        }

        public IEnumerable<SongGeneralInfoProjection> GetAll()
        {
            return this.Repository.GetMany(
                _ => true,
                s => new SongGeneralInfoProjection
                {
                    Id = s.Id,
                    Name = s.Name,
                    ArtistNickname = s.Artist.Nickname
                });
        }
    }
}
