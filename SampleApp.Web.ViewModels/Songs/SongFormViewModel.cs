using SampleApp.Web.ViewModels.Artists;
using SampleApp.Web.ViewModels.Genres;

namespace SampleApp.Web.ViewModels.Songs
{
    public record SongFormViewModel<TInputModel>
    {
        public required IEnumerable<ArtistMinifiedViewModel> Artists { get; init; }
        public required IEnumerable<GenreMinifiedViewModel> Genres { get; init; }
        public TInputModel? InputModel { get; init; }
    }
}
