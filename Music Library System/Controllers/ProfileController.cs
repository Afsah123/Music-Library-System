using Microsoft.AspNetCore.Mvc;
using Music_Library_System.Models;

namespace Music_Library_System.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var userProfile = new UserProfile
            {
                Id = 1,
                UserName = "Afsah Ur Rehman Zaidi",
                Email = "afsah@example.com",
                ProfileImageUrl = "https://picsum.photos/id/25/300/300",
                TotalPlaylists = 5,
                FavoriteSongs = 42
            };

            return View(userProfile);
        }
    }
}