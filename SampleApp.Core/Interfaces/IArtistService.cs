using SampleApp.Core.Projections.Artists;
using SampleApp.Data.Models;

namespace SampleApp.Core.Interfaces
{
    public interface IArtistService : IService<Artist>
    {
        IEnumerable<ArtistGeneralInfoProjection> GetAll();
    }
}
