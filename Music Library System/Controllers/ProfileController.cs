using Microsoft.AspNetCore.Mvc;
using Music_Library_System.Models;
using System.Collections.Generic;

namespace Music_Library_System.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var userProfile = new UserProfile
            {
                Id = 1,
                Username = "Afsah Ur Rehman Zaidi",
                Email = "afsah@example.com",
                ProfilePictureUrl = "https://picsum.photos/id/25/300/300",
                Bio = "Music enthusiast and collector",
                JoinDate = new DateTime(2024, 1, 1),
                Playlists = new List<Playlist>(),
                FavoriteSongs = new List<Song>(),
                FavoriteAlbums = new List<Album>(),
                FavoriteArtists = new List<Artist>()
            };

            return View(userProfile);
        }
    }
}