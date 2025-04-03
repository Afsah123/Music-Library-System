using Microsoft.AspNetCore.Mvc;
using MusicLibrarySystem.Models;
using System.Collections.Generic;

namespace MusicLibrarySystem.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            var playlists = new List<Playlist>
            {
                new Playlist { Id = 1, Name = "Rock Classics", Description = "Best rock songs of all time", SongCount = 15, CoverImageUrl = "https://picsum.photos/id/13/300/300" },
                new Playlist { Id = 2, Name = "Chill Vibes", Description = "Relaxing music for study sessions", SongCount = 20, CoverImageUrl = "https://picsum.photos/id/14/300/300" },
                new Playlist { Id = 3, Name = "Workout Mix", Description = "High energy tracks for your workout", SongCount = 12, CoverImageUrl = "https://picsum.photos/id/15/300/300" }
            };

            return View(playlists);
        }

        public IActionResult Details(int id)
        {
            var playlist = new Playlist
            {
                Id = id,
                Name = "Rock Classics",
                Description = "Best rock songs of all time",
                SongCount = 15,
                CoverImageUrl = "https://picsum.photos/id/13/300/300"
            };

            var songs = new List<Song>
            {
                new Song { Id = 1, Title = "Back in Black", ArtistName = "AC/DC", AlbumTitle = "Back in Black", Duration = "4:15", CoverImageUrl = "https://picsum.photos/id/10/300/300" },
                new Song { Id = 2, Title = "Smoke on the Water", ArtistName = "Deep Purple", AlbumTitle = "Machine Head", Duration = "5:40", CoverImageUrl = "https://picsum.photos/id/16/300/300" },
                new Song { Id = 3, Title = "Stairway to Heaven", ArtistName = "Led Zeppelin", AlbumTitle = "Led Zeppelin IV", Duration = "8:02", CoverImageUrl = "https://picsum.photos/id/17/300/300" }
            };

            ViewBag.Songs = songs;

            return View(playlist);
        }
    }
}