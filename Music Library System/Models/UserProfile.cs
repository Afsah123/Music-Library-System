namespace Music_Library_System.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public DateTime JoinDate { get; set; }
        
        // Navigation properties
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<Song> FavoriteSongs { get; set; }
        public ICollection<Album> FavoriteAlbums { get; set; }
        public ICollection<Artist> FavoriteArtists { get; set; }
        
        // Additional properties
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
