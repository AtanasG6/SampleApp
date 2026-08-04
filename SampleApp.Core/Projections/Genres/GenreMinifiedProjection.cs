namespace SampleApp.Core.Projections.Genres
{
    public record GenreMinifiedProjection
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }
    }
}
