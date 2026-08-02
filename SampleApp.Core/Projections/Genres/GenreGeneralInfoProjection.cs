namespace SampleApp.Core.Projections.Genres
{
    public record GenreGeneralInfoProjection
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }
    }
}
