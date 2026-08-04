namespace SampleApp.Web.ViewModels.Songs
{
    public record SongCreateModel
    {
        public required string Name { get; init; }
        public required Guid Artist { get; init; }
        public required IEnumerable<Guid> Genres { get; init; }
    }
}
