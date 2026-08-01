namespace SampleApp.Experiments.Projections
{
    internal record SongInfoProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ArtistNickname { get; init; }
    }
}
