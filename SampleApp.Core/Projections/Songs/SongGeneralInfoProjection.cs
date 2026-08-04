using SampleApp.Core.Projections.Artists;
using SampleApp.Core.Projections.Genres;

namespace SampleApp.Core.Projections.Songs
{
    public record SongGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ArtistMinifiedProjection Artist { get; init; }
        public required IEnumerable<GenreMinifiedProjection> Genres { get; init; }
    }
}
