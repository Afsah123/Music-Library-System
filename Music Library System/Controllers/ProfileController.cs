using Microsoft.AspNetCore.Mvc;
using Music_Library_System.Models;
using System.Collections.Generic;

namespace Music_Library_System.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Profile/Edit
        public IActionResult Edit()
        {
            // In a real application, you would get the current user's ID from the session/authentication
            var userId = 1; // This is just for demo purposes
            var userProfile = new UserProfile
            {
                Id = userId,
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

        // POST: Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                // In a real application, you would update the user in the database
                // For now, we'll just redirect back to the profile page
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }
    }
}