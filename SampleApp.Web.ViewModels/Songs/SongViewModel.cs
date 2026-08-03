using SampleApp.Web.ViewModels.Artists;

namespace SampleApp.Web.ViewModels.Songs
{
    public record SongViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ArtistMinifiedViewModel Artist { get; init; }
    }
}
