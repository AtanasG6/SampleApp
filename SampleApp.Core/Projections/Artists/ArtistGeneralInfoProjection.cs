using SampleApp.Core.Projections.Songs;

namespace SampleApp.Core.Projections.Artists
{
    public record ArtistGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Nickname { get; init; }
        public required SongMinifiedProjection[] Songs { get; init; }
    }
}
