namespace Music_Library_System.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsPublic { get; set; }
        
        // Navigation properties
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<Song> Songs { get; set; }
        
        // Additional properties
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
