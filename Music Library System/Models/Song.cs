namespace Music_Library_System.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string AlbumTitle { get; set; }
        public string Duration { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
