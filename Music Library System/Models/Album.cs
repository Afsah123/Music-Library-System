namespace Music_Library_System.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string CoverImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public int SongCount { get; set; }
    }
}