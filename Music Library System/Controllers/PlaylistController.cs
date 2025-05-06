using Microsoft.AspNetCore.Mvc;
using Music_Library_System.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

namespace Music_Library_System.Controllers
{
    public class PlaylistController : Controller
    {
        private static List<Playlist> Playlists = null;
        private static int NextId = 4;

        private void EnsureDefaultPlaylists()
        {
            if (Playlists == null)
            {
                Playlists = new List<Playlist>
                {
                    new Playlist { 
                        Id = 1, 
                        Name = "Rock Classics", 
                        Description = "Best rock songs of all time", 
                        CoverImageUrl = "https://picsum.photos/id/669/400/400",
                        IsPublic = true,
                        UserProfile = new UserProfile { Id = 1, Username = "user1" },
                        Songs = new List<Song>()
                    },
                    new Playlist { 
                        Id = 2, 
                        Name = "Chill Vibes", 
                        Description = "Relaxing music for study sessions", 
                        CoverImageUrl = "https://picsum.photos/id/69/400/400",
                        IsPublic = true,
                        UserProfile = new UserProfile { Id = 1, Username = "user1" },
                        Songs = new List<Song>()
                    },
                    new Playlist { 
                        Id = 3, 
                        Name = "Workout Mix", 
                        Description = "High energy tracks for your workout", 
                        CoverImageUrl = "https://picsum.photos/id/67/400/400",
                        IsPublic = true,
                        UserProfile = new UserProfile { Id = 1, Username = "user1" },
                        Songs = new List<Song>()
                    }
                };
            }
        }

        public IActionResult Index()
        {
            EnsureDefaultPlaylists();
            return View(Playlists);
        }

        public IActionResult Details(int id)
        {
            EnsureDefaultPlaylists();
            var playlist = Playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null)
                return NotFound();

            // For demo, add some songs if empty
            if (playlist.Songs == null || !playlist.Songs.Any())
            {
                playlist.Songs = new List<Song>
                {
                    new Song { 
                        Id = 1, 
                        Title = "Back in Black", 
                        Duration = "4:15", 
                        Genre = "Rock",
                        AudioUrl = "https://example.com/songs/back-in-black.mp3",
                        Lyrics = "Back in black...",
                        TrackNumber = 1,
                        Artist = new Artist { 
                            Id = 2, 
                            Name = "AC/DC",
                            ImageUrl = "https://picsum.photos/id/237/400/400"
                        },
                        Album = new Album { 
                            Id = 2, 
                            Title = "Back in Black",
                            CoverImageUrl = "https://picsum.photos/id/238/400/400"
                        }
                    },
                    new Song { 
                        Id = 2, 
                        Title = "Smoke on the Water", 
                        Duration = "5:40", 
                        Genre = "Rock",
                        AudioUrl = "https://example.com/songs/smoke-on-the-water.mp3",
                        Lyrics = "We all came out to Montreux...",
                        TrackNumber = 1,
                        Artist = new Artist { 
                            Id = 5, 
                            Name = "Deep Purple",
                            ImageUrl = "https://picsum.photos/id/239/400/400"
                        },
                        Album = new Album { 
                            Id = 5, 
                            Title = "Machine Head",
                            CoverImageUrl = "https://picsum.photos/id/240/400/400"
                        }
                    },
                    new Song { 
                        Id = 3, 
                        Title = "Stairway to Heaven", 
                        Duration = "8:02", 
                        Genre = "Rock",
                        AudioUrl = "https://example.com/songs/stairway-to-heaven.mp3",
                        Lyrics = "There's a lady who's sure...",
                        TrackNumber = 4,
                        Artist = new Artist { 
                            Id = 6, 
                            Name = "Led Zeppelin",
                            ImageUrl = "https://picsum.photos/id/241/400/400"
                        },
                        Album = new Album { 
                            Id = 6, 
                            Title = "Led Zeppelin IV",
                            CoverImageUrl = "https://picsum.photos/id/242/400/400"
                        }
                    }
                };
            }

            ViewBag.Songs = playlist.Songs;
            return View(playlist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var session = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(session))
            {
                TempData["AuthMessage"] = "You must log in or sign up to create a playlist.";
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name, string Description, string CoverImageUrl, bool IsPublic)
        {
            EnsureDefaultPlaylists();
            var newPlaylist = new Playlist
            {
                Id = NextId++,
                Name = Name,
                Description = Description,
                CoverImageUrl = string.IsNullOrWhiteSpace(CoverImageUrl) ? 
                    $"https://picsum.photos/id/{new Random().Next(1, 1000)}/400/400" : 
                    CoverImageUrl,
                IsPublic = IsPublic,
                UserProfile = new UserProfile { Id = 1, Username = "user1" }, // For demo, static user
                Songs = new List<Song>(),
                CreatedAt = DateTime.Now
            };
            Playlists.Add(newPlaylist);
            return RedirectToAction("Index");
        }
    }
}