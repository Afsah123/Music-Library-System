namespace Music_Library_System.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public int TotalPlaylists { get; set; }
        public int FavoriteSongs { get; set; }
    }
}
