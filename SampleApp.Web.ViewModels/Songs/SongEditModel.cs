namespace SampleApp.Web.ViewModels.Songs
{
    public record SongEditModel : SongCreateModel
    {
        public required Guid Id { get; init; }
    }
}
