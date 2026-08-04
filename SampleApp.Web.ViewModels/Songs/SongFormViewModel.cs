using SampleApp.Web.ViewModels.Artists;
using SampleApp.Web.ViewModels.Genres;

namespace SampleApp.Web.ViewModels.Songs
{
    public record SongFormViewModel
    {
        public SongCreateModel? InputModel { get; init; }
        public required IEnumerable<ArtistMinifiedViewModel> Artists { get; init; }
        public required IEnumerable<GenreMinifiedViewModel> Genres { get; init; }
    }
}
