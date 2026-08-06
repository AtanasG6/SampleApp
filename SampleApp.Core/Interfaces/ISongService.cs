using SampleApp.Core.Projections.Songs;
using SampleApp.Data.Models;

namespace SampleApp.Core.Interfaces
{
    public interface ISongService : IService<Song>
    {
        IEnumerable<SongGeneralInfoProjection> GetAll();
        SongMinifiedProjection? GetOneMinified(Guid id);
    }
}
