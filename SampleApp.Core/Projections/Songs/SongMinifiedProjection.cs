namespace SampleApp.Core.Projections.Songs
{
    public record SongMinifiedProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
