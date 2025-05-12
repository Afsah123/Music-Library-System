namespace MusicLibraryBackend.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsPublic { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<Song> Songs { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 