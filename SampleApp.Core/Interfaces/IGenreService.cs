using SampleApp.Core.Projections.Genres;
using SampleApp.Data.Models;

namespace SampleApp.Core.Interfaces
{
    public interface IGenreService : IService<Genre>
    {
        IEnumerable<GenreGeneralInfoProjection> GetAll();
    }
}
