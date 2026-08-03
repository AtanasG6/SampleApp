using SampleApp.Core.Projections.Artists;

namespace SampleApp.Core.Projections.Songs
{
    public record SongGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ArtistMinifiedProjection Artist { get; init; }
    }
}
