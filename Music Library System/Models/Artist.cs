namespace Music_Library_System.Models
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
        
        // Navigation properties
        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
        
        // Additional properties
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
