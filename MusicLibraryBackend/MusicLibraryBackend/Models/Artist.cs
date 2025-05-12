namespace MusicLibraryBackend.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 