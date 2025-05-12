namespace MusicLibraryBackend.Models
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Number { get; set; }
        public string ProfilePicturePath { get; set; }
        public bool IsLoggedIn { get; set; }
    }
} 