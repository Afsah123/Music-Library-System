namespace Music_Library_System.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SongCount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
