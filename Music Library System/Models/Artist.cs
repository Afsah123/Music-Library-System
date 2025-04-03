namespace Music_Library_System.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int NumAlbums { get; set; }
        public int NumSongs { get; set; }
    }
}
