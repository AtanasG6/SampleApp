namespace SampleApp.Data.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
