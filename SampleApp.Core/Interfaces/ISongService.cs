using SampleApp.Core.Projections.Songs;
using SampleApp.Data.Models;

namespace SampleApp.Core.Interfaces
{
    public interface ISongService : IService<Song>
    {
        IEnumerable<SongGeneralInfoProjection> GetAll();
        SongGeneralInfoProjection? GetOne(Guid id);
        SongMinifiedProjection? GetOneMinified(Guid id);
        SongEditProjection? GetOneEdit(Guid id);
    }
}
