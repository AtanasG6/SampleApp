using SampleApp.Core.Projections.Genres;
using SampleApp.Data.Models;

namespace SampleApp.Core.Interfaces
{
    public interface IGenreService : IService<Genre>
    {
        IEnumerable<GenreGeneralInfoProjection> GetAll();
        GenreGeneralInfoProjection? GetOne(Guid id);

        IEnumerable<GenreMinifiedProjection> GetAllMinified();
        GenreMinifiedProjection? GetOneMinified(Guid id);

        GenreEditProjection? GetOneEdit(Guid id);
    }
}
