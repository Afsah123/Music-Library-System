using System.Text.Json;

namespace Music_Library_System.Models
{
    public class UserSession
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Number { get; set; }
        public string ProfilePicturePath { get; set; }
        public bool IsLoggedIn { get; set; }

        public static UserSession FromUserModel(UserModel user)
        {
            return new UserSession
            {
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Number = user.Number,
                ProfilePicturePath = user.ProfilePicturePath,
                IsLoggedIn = true
            };
        }
    }
} 